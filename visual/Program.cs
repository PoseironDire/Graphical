using System;
using System.Numerics;
using Raylib_cs;

namespace Visual
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = 1400;
            int h = 800;

            float speedX = w / 2 - 200;
            float speedY = h / 2;
            float speedX2 = w / 2 + 200;
            float speedY2 = h / 2;

            int playerSize = 25;
            int player2Size = 25;
            int playerRadarSize = 70;

            float speedP1 = 10.5f;
            float speedP2 = 7.5f;

            string scene = "intro";

            Color menuBG = new Color(100, 200, 140, 255);
            Color guideBG = new Color(200, 50, 20, 255);
            Color gameBG = new Color(100, 250, 40, 255);

            Image icon = Raylib.LoadImage(@"Smiley.png");

            Raylib.InitWindow(w, h, "");
            Raylib.SetTargetFPS(60);
            Raylib.SetExitKey(0);
            Raylib.SetWindowTitle("A Game Created By Esvin");
            Raylib.SetWindowIcon(icon);

            Texture2D bgImage = Raylib.LoadTexture("bg.png");

            while (!Raylib.WindowShouldClose())
            {
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_E))
                {
                    Raylib.CloseWindow();
                }
                if (scene == "intro")
                {
                    Raylib.ClearBackground(menuBG);
                    Raylib.DrawText("Welcome To A Game!", 175, h / 2 - 50, 100, Color.WHITE);
                    Raylib.DrawText("Press ENTER To Play!", 400, h / 2 + 50, 45, Color.WHITE);
                    Raylib.DrawText("Press G To See Guide!", 400, h / 2 + 100, 45, Color.WHITE);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        scene = "game";
                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_G))
                    {
                        scene = "guide";
                    }
                }
                else if (scene == "guide")
                {
                    Raylib.ClearBackground(guideBG);
                    Raylib.DrawText("P1 (blue) Seeker: w,a,s,d", 375, h / 2 - 100, 50, Color.WHITE);
                    Raylib.DrawText("P2 (red) Runner: i,j,k,l", 375, h / 2, 50, Color.WHITE);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE) || Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        scene = "intro";
                    }
                }
                else if (scene == "game")
                {
                    Raylib.ClearBackground(gameBG);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
                    {
                        scene = "menu";
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                    {
                        speedP2 = 15.5f;
                    }
                    else
                    {
                        speedP2 = 7.5f;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                    {
                        speedX += speedP1;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                    {
                        speedX -= speedP1;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                    {
                        speedY -= speedP1;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                    {
                        speedY += speedP1;
                    }
                    if (speedX <= 0 + playerSize)
                    {
                        speedX = 0 + playerSize;
                    }
                    if (speedX >= w - playerSize)
                    {
                        speedX = w - playerSize;
                    }
                    if (speedY <= 0 + playerSize)
                    {
                        speedY = 0 + playerSize;
                    }
                    if (speedY >= h - playerSize)
                    {
                        speedY = h - playerSize;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_L))
                    {
                        speedX2 += speedP2;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_J))
                    {
                        speedX2 -= speedP2;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_I))
                    {
                        speedY2 -= speedP2;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_K))
                    {
                        speedY2 += speedP2;
                    }
                    if (speedX2 <= 0 + player2Size)
                    {
                        speedX2 = 0 + player2Size;
                    }
                    if (speedX2 >= w - player2Size)
                    {
                        speedX2 = w - player2Size;
                    }
                    if (speedY2 <= 0 + player2Size)
                    {
                        speedY2 = 0 + player2Size;
                    }
                    if (speedY2 >= h - player2Size)
                    {
                        speedY2 = h - player2Size;
                    }
                }
                if (!(scene == "intro" || scene == "guide"))
                {
                    Raylib.BeginDrawing();

                    Color purpleRadar = new Color(123, 30, 230, 150);
                    Color grayish = new Color(200, 200, 200, 200);

                    Raylib.ClearBackground(Color.DARKGRAY);

                    Raylib.DrawRectangle(30, 30, w - 60, h - 60, grayish);

                    Raylib.DrawTextureEx(bgImage, new Vector2(25, 25), 0f, 0.84f, Color.WHITE);

                    Raylib.DrawCircle((int)speedX2, (int)speedY2, playerSize, Color.RED);

                    Raylib.DrawCircle((int)speedX, (int)speedY, playerRadarSize, purpleRadar);

                    Raylib.DrawCircle((int)speedX, (int)speedY, playerSize, Color.BLUE);
                }
                if (scene == "menu")
                {
                    Color graymenu = new Color(50, 50, 50, 100);

                    Raylib.DrawRectangle(0, 0, w, 150, graymenu);
                    Raylib.DrawRectangle(0, h - 150, w, h, graymenu);
                    Raylib.DrawText("Menu Sceen", 400, h / 2 - 50, 100, Color.WHITE);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE) || Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        scene = "game";
                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                    {
                        scene = "intro";

                        speedX = w / 2 - 200;
                        speedY = h / 2;
                        speedX2 = w / 2 + 200;
                        speedY2 = h / 2;
                    }
                }
                Raylib.EndDrawing();
            }
        }
    }
}
