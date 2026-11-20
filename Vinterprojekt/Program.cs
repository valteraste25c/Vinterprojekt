using System.ComponentModel;
using System.Numerics;
using System.Xml;
using Raylib_cs;

Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint);
Raylib.InitWindow(800, 600, "my window");
Raylib.SetTargetFPS(60);

const int ScreenWidth = 800;
const int ScreenHeight = 600;


// int amount = 4;
// int width = 50;
// int gap = (800 - amount * width) / (amount + 1);
int enemyhp = 100;
// float speed = 0;
// float percent = 1;
float shotcooldown = 0;
float shotdelay = 0.25f;
float EnemySpeed = 300;
float PlayerSpeed = 600;
Rectangle playerbox = new Rectangle(50, 450, 75, 100);
Rectangle enemybox = new Rectangle(350, 50, 75, 100);

List<Rectangle>bullets = new List<Rectangle>();

// Rectangle[] walls = new Rectangle[]
// {
//     new Rectangle(gap, 0, width, 100),
//     new Rectangle(gap * 2 + width, 0, width, 100),
//     new Rectangle(gap * 3 + width * 2, 0, width, 100),
//     new Rectangle(gap * 4 + width * 3, 0, width, 100)
// };
// int jumpstat = 0;


while (!Raylib.WindowShouldClose())
{


    float FrameTime = Raylib.GetFrameTime();

    for (int i = bullets.Count - 1; i >= 0; i--)
    {
        if (Raylib.CheckCollisionRecs(bullets[i], enemybox))
        {
            bullets.RemoveAt(i);
            enemyhp -= 5;

        }
    }

    if (shotcooldown > 0)
        shotcooldown -= FrameTime;


    if (Raylib.IsKeyDown(KeyboardKey.Space) && shotcooldown <= 0)
        {
            bullets.Add(new Rectangle(playerbox.X + playerbox.Width / 2 - 2.5f, playerbox.Y, 10, 10));
            shotcooldown = shotdelay;
        }
    for (int i = 0; i < bullets.Count; i++)
    {
        Rectangle b = bullets[i];
        b.Y -= 500 * FrameTime;
        bullets[i] = b;
    }

    bullets.RemoveAll(b => b.Y < -10);
    
    // for (int i = 0; i < walls.Length; i++)
    // {
    //     walls[i].Y += speed * percent * Raylib.GetFrameTime();

    //     if (walls[i].Y > 600)
    //     {
    //         walls[i].Y = -walls[i].Height;
    //         percent += (float)Random.Shared.NextDouble();
    //     }
    //     if (percent > 10)
    //         percent = 10;
    // }

    if (Raylib.IsKeyDown(KeyboardKey.D))
            playerbox.X += PlayerSpeed * FrameTime;
    if (Raylib.IsKeyDown(KeyboardKey.A))
        playerbox.X -= PlayerSpeed * FrameTime;

    playerbox.X = Math.Clamp(playerbox.X, 0, ScreenWidth - playerbox.Width);

    enemybox.X += EnemySpeed;

    if (enemybox.X > 725)
        EnemySpeed = -300 * FrameTime;

    else if (enemybox.X < 0)
        EnemySpeed = 300 * FrameTime;

    enemybox.X = Math.Clamp(enemybox.X, 0, ScreenWidth - enemybox.Width);


    Raylib.BeginDrawing();


    Raylib.ClearBackground(Color.White);
    Raylib.DrawRectangleRec(playerbox, Color.Green);
    if (enemyhp > 0)
    {
        Raylib.DrawRectangleRec(enemybox, Color.Red);
        Raylib.DrawText(enemyhp + "/100", (int)enemybox.X, (int)enemybox.Y - 25, 20, Color.Black);
    }

    // foreach (Rectangle wall in walls)
    // {
    //     Raylib.DrawRectangleRec(wall, Color.Red);
    // }

    foreach (Rectangle bullet in bullets)
        Raylib.DrawRectangleRec(bullet, Color.Black);
    


    Raylib.EndDrawing();
}