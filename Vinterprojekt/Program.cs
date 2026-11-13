using Raylib_cs;

Raylib.InitWindow(800, 600, "my window");
Raylib.SetTargetFPS(60);

Rectangle playerBox = new(0,550,50,50);
Camera2D camera = new Camera2D();
camera.Zoom = 1f;


while (!Raylib.WindowShouldClose())
{

    if(Raylib.IsKeyDown(KeyboardKey.D))
    playerBox.X += 10;
    if(Raylib.IsKeyDown(KeyboardKey.A))
    playerBox.X -= 10;
    if(Raylib.IsKeyPressed(KeyboardKey.Space))
    
    
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);

    Raylib.DrawRectangleRec(playerBox, Color.Green);

    Raylib.EndDrawing();
}