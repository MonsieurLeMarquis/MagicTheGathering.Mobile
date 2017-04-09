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

                DrawFontFitTextView(screen.ZoneOpponent.ScoreOpponent.Widget, score.LifePoints_Opponent.ToString(), "Fonts/ComicBook.ttf", Colors.FontColor_Score, Themes.Score, frameLayout, activity);
                DrawFontFitTextView(screen.ZoneOpponent.ScorePlayer.Widget, score.LifePoints_Player.ToString(), "Fonts/ComicBook.ttf", Colors.FontColor_Score, Themes.Score, frameLayout, activity);
                DrawFontFitTextView(screen.ZonePlayer.ScorePlayer.Widget, score.LifePoints_Player.ToString(), "Fonts/ComicBook.ttf", Colors.FontColor_Score, Themes.Score, frameLayout, activity);
                DrawFontFitTextView(screen.ZonePlayer.ScoreOpponent.Widget, score.LifePoints_Opponent.ToString(), "Fonts/ComicBook.ttf", Colors.FontColor_Score, Themes.Score, frameLayout, activity);
                DrawFontFitTextView(screen.ZoneOpponent.NameOpponent.Widget, "P B", "Fonts/ComicBook.ttf", Colors.FontColor_PlayerName, Themes.PlayerName, frameLayout, activity);
                DrawFontFitTextView(screen.ZoneOpponent.NamePlayer.Widget, "Player", "Fonts/ComicBook.ttf", Colors.FontColor_PlayerName, Themes.PlayerName, frameLayout, activity);
                DrawFontFitTextView(screen.ZonePlayer.NamePlayer.Widget, "Player name A", "Fonts/ComicBook.ttf", Colors.FontColor_PlayerName, Themes.PlayerName, frameLayout, activity);
                DrawFontFitTextView(screen.ZonePlayer.NameOpponent.Widget, "B", "Fonts/ComicBook.ttf", Colors.FontColor_PlayerName, Themes.PlayerName, frameLayout, activity);

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

        public static void RefreshScores(Screen screen, Game.Score score, Activity activity)
        {
            if (ManagerScreen.IsValid(screen))
            {
                Drawing.ManagerDrawing.SetText(screen.ZoneOpponent.ScoreOpponent.Widget, score.LifePoints_Opponent.ToString(), ManagerSize.GetOptimalFontSize(score.LifePoints_Opponent.ToString(), screen.ZoneOpponent.ScoreOpponent.Width, activity));
                Drawing.ManagerDrawing.SetText(screen.ZoneOpponent.ScorePlayer.Widget, score.LifePoints_Player.ToString(), ManagerSize.GetOptimalFontSize(score.LifePoints_Player.ToString(), screen.ZoneOpponent.ScorePlayer.Width, activity));
                Drawing.ManagerDrawing.SetText(screen.ZonePlayer.ScorePlayer.Widget, score.LifePoints_Player.ToString(), ManagerSize.GetOptimalFontSize(score.LifePoints_Player.ToString(), screen.ZonePlayer.ScorePlayer.Width, activity));
                Drawing.ManagerDrawing.SetText(screen.ZonePlayer.ScoreOpponent.Widget, score.LifePoints_Opponent.ToString(), ManagerSize.GetOptimalFontSize(score.LifePoints_Opponent.ToString(), screen.ZonePlayer.ScoreOpponent.Width, activity));
            }
        }

    }
}