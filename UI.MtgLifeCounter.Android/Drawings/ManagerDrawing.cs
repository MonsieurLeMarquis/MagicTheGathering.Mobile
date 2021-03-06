using Android.App;
using Android.Graphics;
using Android.Widget;
using Business.MtgLifeCounter.Managers;
using Business.MtgLifeCounter.Widgets;
using Common.Android.Animations;
using Drawing = Common.Android.Drawing;
using Game = Business.MtgLifeCounter.Game;

namespace UI.MtgLifeCounter.Android.Drawings
{
    public class ManagerDrawing
    {

        public static void DrawScreen(Screen screen, Game.Score score, FrameLayout frameLayout, Activity activity)
        {
         
            if (ManagerScreen.IsValid(screen) && frameLayout != null)
            {

                DrawFontFitTextView(screen.ZoneOpponent.ScoreOpponent.Widget, "0", "Fonts/ComicBook.ttf", Colors.FontColor_Score, Themes.Score, frameLayout, activity);
                DrawFontFitTextView(screen.ZoneOpponent.ScorePlayer.Widget, "0", "Fonts/ComicBook.ttf", Colors.FontColor_Score, Themes.Score, frameLayout, activity);
                DrawFontFitTextView(screen.ZonePlayer.ScorePlayer.Widget, "0", "Fonts/ComicBook.ttf", Colors.FontColor_Score, Themes.Score, frameLayout, activity);
                DrawFontFitTextView(screen.ZonePlayer.ScoreOpponent.Widget, "0", "Fonts/ComicBook.ttf", Colors.FontColor_Score, Themes.Score, frameLayout, activity);
                DrawFontFitTextView(screen.ZoneOpponent.NameOpponent.Widget, "", "Fonts/ComicBook.ttf", Colors.FontColor_PlayerName, Themes.PlayerName, frameLayout, activity);
                DrawFontFitTextView(screen.ZoneOpponent.NamePlayer.Widget, "", "Fonts/ComicBook.ttf", Colors.FontColor_PlayerName, Themes.PlayerName, frameLayout, activity);
                DrawFontFitTextView(screen.ZonePlayer.NamePlayer.Widget, "", "Fonts/ComicBook.ttf", Colors.FontColor_PlayerName, Themes.PlayerName, frameLayout, activity);
                DrawFontFitTextView(screen.ZonePlayer.NameOpponent.Widget, "", "Fonts/ComicBook.ttf", Colors.FontColor_PlayerName, Themes.PlayerName, frameLayout, activity);

                DrawScore(screen.ZoneOpponent.ScoreOpponent, ManagerScreen.GetPosition_ZoneOpponent_ScoreOpponent(screen), frameLayout, true);
                DrawScore(screen.ZoneOpponent.ScorePlayer, ManagerScreen.GetPosition_ZoneOpponent_ScorePlayer(screen), frameLayout, true);
                DrawScore(screen.ZonePlayer.ScorePlayer, ManagerScreen.GetPosition_ZonePlayer_ScorePlayer(screen), frameLayout, false);
                DrawScore(screen.ZonePlayer.ScoreOpponent, ManagerScreen.GetPosition_ZonePlayer_ScoreOpponent(screen), frameLayout, false);
                DrawPlayerName(screen.ZoneOpponent.NameOpponent, ManagerScreen.GetPosition_ZoneOpponent_NameOpponent(screen), frameLayout, true);
                DrawPlayerName(screen.ZoneOpponent.NamePlayer, ManagerScreen.GetPosition_ZoneOpponent_NamePlayer(screen), frameLayout, true);
                DrawPlayerName(screen.ZonePlayer.NamePlayer, ManagerScreen.GetPosition_ZonePlayer_NamePlayer(screen), frameLayout, false);
                DrawPlayerName(screen.ZonePlayer.NameOpponent, ManagerScreen.GetPosition_ZonePlayer_NameOpponent(screen), frameLayout, false);

            }

        }

        private static void DrawFontFitTextView(TextView textView, string text, string font, Color fontColor, Drawing.ThemeDrawable theme, FrameLayout frameLayout, Activity activity)
        {
            Drawing.ManagerDrawing.SetText(textView, text);
            Drawing.ManagerDrawing.SetFontColor(textView, fontColor);
            Drawing.ManagerDrawing.SetTheme(textView, theme);
            Drawing.ManagerDrawing.SetFont(textView, font, activity);
        }

        private static void DrawScore(Score score, Position position, FrameLayout frameLayout, bool rotation)
        {
            Drawing.ManagerDrawing.ShowTextView(score.Widget, score.Height, score.Width, position.X, position.Y, frameLayout);
            if (rotation)
            {
                Rotation.RotateTextView(score.Widget, score.Height, score.Width, 180);
            }
        }

        private static void DrawPlayerName(PlayerName playerName, Position position, FrameLayout frameLayout, bool rotation)
        {
            Drawing.ManagerDrawing.ShowTextView(playerName.Widget, playerName.Height, playerName.Width, position.X, position.Y, frameLayout);
            if (rotation)
            {
                Rotation.RotateTextView(playerName.Widget, playerName.Height, playerName.Width, 180);
            }
        }

        public static void RefreshAll(Screen screen, Game.Score score)
        {
            RefreshScores(screen, score);
            RefreshPlayersNames(screen);
        }

        public static void RefreshScores(Screen screen, Game.Score score)
        {
            if (ManagerScreen.IsValid(screen))
            {
                Drawing.ManagerDrawing.SetText(screen.ZoneOpponent.ScoreOpponent.Widget, ManagerScore.GetScoreText(score.LifePoints_Opponent));
                Drawing.ManagerDrawing.SetText(screen.ZoneOpponent.ScorePlayer.Widget, ManagerScore.GetScoreText(score.LifePoints_Player));
                Drawing.ManagerDrawing.SetText(screen.ZonePlayer.ScorePlayer.Widget, ManagerScore.GetScoreText(score.LifePoints_Player));
                Drawing.ManagerDrawing.SetText(screen.ZonePlayer.ScoreOpponent.Widget, ManagerScore.GetScoreText(score.LifePoints_Opponent));
            }
        }

        public static void RefreshPlayersNames(Screen screen)
        {
            if (ManagerScreen.IsValid(screen))
            {
                /*
                Drawing.ManagerDrawing.SetText(screen.ZoneOpponent.ScoreOpponent.Widget, screen.ZoneOpponent.ScoreOpponent.Widget.Text);
                Drawing.ManagerDrawing.SetText(screen.ZoneOpponent.ScorePlayer.Widget, screen.ZoneOpponent.ScorePlayer.Widget.Text);
                Drawing.ManagerDrawing.SetText(screen.ZonePlayer.ScorePlayer.Widget, screen.ZonePlayer.ScorePlayer.Widget.Text);
                Drawing.ManagerDrawing.SetText(screen.ZonePlayer.ScoreOpponent.Widget, screen.ZonePlayer.ScoreOpponent.Widget.Text);
                */
                Drawing.ManagerDrawing.SetText(screen.ZoneOpponent.NameOpponent.Widget, "Player");
                Drawing.ManagerDrawing.SetText(screen.ZoneOpponent.NamePlayer.Widget, "Long Player Name");
                Drawing.ManagerDrawing.SetText(screen.ZonePlayer.NamePlayer.Widget, "P");
                Drawing.ManagerDrawing.SetText(screen.ZonePlayer.NameOpponent.Widget, "Very Very Long Player Name");
            }
        }

    }
}