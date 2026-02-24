using System;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Prog;

#region Classe Ponto
public class Point
{
	private Vector3 velocity;
	private Vector3 position;
	private Color col;
	private float radius;

	public Point( int _x, int _y, float _z, Color _col )
	{
		position.X = _x;
		position.Y = _y;
		position.Z = _z;
		col = _col;
		radius = 0.5f;
		velocity = new( 0, 0, 0 );
	}

	public void Draw()
	{
		DrawSphere( GetPosition(), radius, col );
	}

	public void SetVelocity( float x, float y, float z )
	{
		velocity.X = x;
		velocity.Y = y;
		velocity.Z = z;
	}

	public void SetVelocity( Vector3 vec )
	{
		velocity.X = vec.X;
		velocity.Y = vec.Y;
		velocity.Z = vec.Z;
	}
	public Vector3 GetVelocity()
	{
		return velocity;
	}

	public void Update()
	{
		position.X += velocity.X;
		position.Y += velocity.Y;
		position.Z += velocity.Z;
	}

	public Vector3 GetPosition()
	{
		return position;
	}

	public float GetRadius()
	{
		return radius;
	}
}
#endregion

public static class Q02
{
	public static Vector3 GetUnitVector( Vector3 vec )
	{
		float s = vec.Length();

		vec.X /= s;
		vec.Y /= s;
		vec.Z /= s;

		return vec;
	}
	private static int WindowWidth = 900;
	private static int WindowHeight = 600;
	public static void Main()
	{
		#region Setup
		SetConfigFlags( ConfigFlags.ResizableWindow );
		InitWindow( WindowWidth, WindowHeight, "win" );
		SetTargetFPS( 60 );

		Camera3D camera = new Camera3D();
		camera.Position = new Vector3( 10, 10, 10 );
		camera.Target = new Vector3( 0, 0, 0 );
		camera.Up = new Vector3( 0, 1, 0);
		camera.FovY = 45.0f;
		camera.Projection = CameraProjection.Perspective;

		Point p1 = new( -2, 0, 0, Color.Blue );
		Point p2 = new( 2, 1, -1, Color.Red );

		bool spin = true;
		bool show_help = true;

		float speed = 0.05f;

		Color PosTx1 = new Color( 10, 10, 200 );
		Color PosTx2 = new Color( 200, 10, 10 );
		float dist;

		#endregion
		
		#region Game Loop
		while(!WindowShouldClose())
		{
			if( IsWindowResized() )
			{
				WindowHeight = GetScreenHeight();
				WindowWidth = GetScreenWidth();
			}
			if ( IsKeyPressed( KeyboardKey.P ) ) spin = !spin;
			if ( IsKeyPressed( KeyboardKey.T ) ) show_help = !show_help;

			Vector3 camForward = Vector3.Normalize( new Vector3(
				camera.Target.X - camera.Position.X,
				0,
				camera.Target.Z - camera.Position.Z
			));

			Vector3 camRight = new Vector3( camForward.Z, 0, -camForward.X );
			if ( spin ) UpdateCamera( ref camera, CameraMode.Orbital );
			else
			{
				float camSpeed = 0.1f;

				Vector3 forward = Vector3.Normalize( camera.Target - camera.Position ) * 2;
				forward.Y = 0;
				forward = Vector3.Normalize( forward );
				Vector3 right = Vector3.Normalize( Vector3.Cross( forward, camera.Up ) );

				Vector3 move = Vector3.Zero;

				if ( IsKeyDown( KeyboardKey.Up ) )    move += new Vector3( 0, camSpeed, 0 );
				if ( IsKeyDown( KeyboardKey.Down ) )  move -= new Vector3( 0, camSpeed, 0 );
				if ( IsKeyDown( KeyboardKey.Right ) ) move += right * camSpeed;
				if ( IsKeyDown( KeyboardKey.Left ) )  move -= right * camSpeed;

				camera.Position += move;
				camera.Target += move;

				float scroll = GetMouseWheelMove();
				if ( scroll != 0 )
				{
					Vector3 direction = Vector3.Normalize( forward );
					camera.Position += direction * -scroll;
				}
			}

			#region Física

			float XA = ( IsKeyDown( KeyboardKey.W ) - IsKeyDown( KeyboardKey.S ) ) * speed;
			float ZA = ( IsKeyDown( KeyboardKey.A ) - IsKeyDown( KeyboardKey.D ) ) * speed;
			float YA = ( IsKeyDown( KeyboardKey.Space ) - IsKeyDown( KeyboardKey.LeftShift ) ) * speed;

			Vector3 vel = camForward * XA + camRight * ZA + new Vector3( 0, YA, 0 );
			p1.SetVelocity( vel );

			Vector3 p1Pos = p1.GetPosition();
			Vector3 p2Pos = p2.GetPosition();

			Vector3 d = new Vector3( p2Pos.X - p1Pos.X, p2Pos.Y - p1Pos.Y, p2Pos.Z - p1Pos.Z );
			Vector3 dN = GetUnitVector( d );
			Vector3 vN = GetUnitVector( p1.GetVelocity() );

			float dot = ( dN.X * vN.X ) + ( dN.Y * vN.Y ) + ( dN.Z * vN.Z );

			p1Pos = p1.GetPosition();
			dist = Vector3.Distance( p1Pos, p2Pos );
			if( dist < p1.GetRadius() + p2.GetRadius() && dot > 0 ) p1.SetVelocity( 0, 0, 0 );

			p1.Update();
			p1.SetVelocity( 0, 0, 0 );

			Vector3 XS = p1.GetPosition();
			XS.X += 2;

			Vector3 ZS = p1.GetPosition();
			ZS.Z += 2;

			Vector3 YS = p1.GetPosition();
			YS.Y += 2;

			#endregion

			#region Drawing
			BeginDrawing();
			BeginMode3D( camera );

			ClearBackground( Color.White );
			p1.Draw();
			p2.Draw();
			DrawGrid( 40, 1 );
			DrawLine3D( p1.GetPosition(), p2.GetPosition(), Color.Black );

			DrawLine3D( p1.GetPosition(), XS, Color.Red );
			DrawLine3D( p1.GetPosition(), YS, Color.Green );
			DrawLine3D( p1.GetPosition(), ZS, Color.Blue );

			EndMode3D();

			Vector2 p1Screen = GetWorldToScreen( p1.GetPosition(), camera );
			Vector2 p2Screen = GetWorldToScreen( p2.GetPosition(), camera );

			DrawText( $"P1: ({p1Pos.X:F1}, {p1Pos.Y:F1}, {p1Pos.Z:F1})", (int)p1Screen.X + 10, (int)p1Screen.Y - 10, 22, PosTx1 );
			DrawText( $"P2: ({p2Pos.X:F1}, {p2Pos.Y:F1}, {p2Pos.Z:F1})", (int)p2Screen.X + 10, (int)p2Screen.Y - 10, 22, PosTx2 );
			DrawText( $"Distancia: {dist}M", 20, 20, 20, Color.Blue );

			if ( show_help )
			{
				DrawText( "Movimento padrão: WASD", WindowWidth - 255, 20, 20, Color.Green );
				DrawText( "Cima - Baixo: Espaço: Shift Esqerdo", WindowWidth - 368, 40, 20, Color.Green );
				DrawText( "Parar / retomar rotação de camera: P", WindowWidth - 408, 60, 20, Color.Green );
				DrawText( "Aproximar / afastar do centro: scroll", WindowWidth - 400, 80, 20, Color.Green );
				DrawText( "Mostrar / Esconder ajuda: T", WindowWidth - 310, 100, 20, Color.Green );
			}

			EndDrawing();
			#endregion
		}
		#endregion

		CloseWindow();
	}
}