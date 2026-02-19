using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Prog;

public class Point
{
	private Vector3 velocity;
	private int x;
	private int y;
	private float z;

	private float radius;

	public Point( int _x, int _y, float _z )
	{
		x = _x;
		y = _y;
		z = _z;
		radius = _z * 0.05f;
		velocity = new( 0, 0, 0 );
	}

	public void Draw()
	{
		DrawCircle( x, y, z * 0.05f, Color.Black );
	}

	public void SetVelocity( int x, int y, int z )
	{
		velocity.X = x;
		velocity.Y = y;
		velocity.Z = z;
	}
	public Vector3 GetVelocity()
	{
		return velocity;
	}

	public void Update()
	{
		x += (int)velocity.X;
		y += (int)velocity.Y;
		z += (int)velocity.Z*3;
	}

	public Vector3 GetPosition()
	{
		return new Vector3( x, y, z );
	}

	public float GetRadius()
	{
		return radius;
	}
}

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
	private const int WindowWidth = 900;
	private const int WindowHeight = 600;
	public static void Main()
	{
		// Setup
		InitWindow( WindowWidth, WindowHeight, "win" );
		SetTargetFPS(60);

		Camera2D camera = new Camera2D();
		camera.Offset = new Vector2( WindowWidth * 0.5f, WindowHeight * 0.5f );
        camera.Rotation = 0.0f;
        camera.Zoom = 1.0f;
		Point p1 = new( -200, 0, 500 );
		Point p2 = new( 200, 0, 500 );
		float dist;

		// Game Loop
		int speed = 4;
		while(!WindowShouldClose())
		{
			// Física
			p1.SetVelocity( ( IsKeyDown( KeyboardKey.D ) - IsKeyDown( KeyboardKey.A ) ) * speed,
				( IsKeyDown( KeyboardKey.S ) - IsKeyDown(KeyboardKey.W ) ) * speed,
				( IsKeyDown( KeyboardKey.Up ) - IsKeyDown(KeyboardKey.Down ) ) * speed
			);

			Vector3 p1Pos = p1.GetPosition();
			Vector3 p2Pos = p2.GetPosition();

			Vector3 d = new Vector3( p2Pos.X - p1Pos.X, p2Pos.Y - p1Pos.Y, p2Pos.Z - p1Pos.Z );
			Vector3 dN = GetUnitVector(d);
			Vector3 vN = GetUnitVector(p1.GetVelocity());

			float dot = ( dN.X * vN.X ) + ( dN.Y * vN.Y ) + ( dN.Z * vN.Z );

			dist = d.Length();
			if( dist < p1.GetRadius() + p2.GetRadius() && dot > 0 ) p1.SetVelocity( 0, 0, 0 );

			p1.Update();
			p1.SetVelocity( 0, 0, 0 );

			// Desenhos
			BeginDrawing();
			BeginMode2D( camera );

			ClearBackground( Color.White );
			p1.Draw();
			p2.Draw();

			DrawText( $"{{ X:{p1Pos.X}, Y:{p1Pos.Y}, Z:{p1Pos.Z} }}", (int)p1Pos.X + 30, (int)p1Pos.Y - 30, 22, Color.Green );
			DrawText( $"{{ X:{p2Pos.X}, Y:{p2Pos.Y}, Z:{p2Pos.Z} }}", (int)p2Pos.X + 30, (int)p2Pos.Y - 30, 22, Color.Green );

			EndMode2D();

			DrawText( $"Distancia: {dist} pixels", 20, 20, 20, Color.Blue );
			EndDrawing();
		}

		CloseWindow();
	}
}