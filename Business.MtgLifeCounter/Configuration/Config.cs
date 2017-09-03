using Business.MtgLifeCounter.Constants;
using System.Collections.Generic;
using static Business.MtgLifeCounter.Enumerations.Enum;

namespace Business.MtgLifeCounter.Configuration
{
    public class Config
    {

        public static int CalibrageTextSizeMin { get; set; }
        public static int CalibrageTextSizeMax { get; set; }

        public static int ScoreStepMultiplePoints
        {
            get
            {
                return Const.CONFIG_SCORE_INCREMENT_STEP_MULTIPLE;
            }
        }

        public static Dictionary<TypeGesture, TypeScoreAction> GesturesActions
        {
            get
            {
                return new Dictionary<TypeGesture, TypeScoreAction>()
                {
                    { TypeGesture.SWIPE_UP, TypeScoreAction.UP_MULTIPLE },
                    { TypeGesture.SWIPE_DOWN, TypeScoreAction.DOWN_MULTIPLE },
                    { TypeGesture.SWIPE_LEFT, TypeScoreAction.HALF },
                    { TypeGesture.SWIPE_RIGHT, TypeScoreAction.DOUBLE },
                    { TypeGesture.TAP_TOP, TypeScoreAction.UP_ONE },
                    { TypeGesture.TAP_BOTTOM, TypeScoreAction.DOWN_ONE },
                    { TypeGesture.TAP_LEFT, TypeScoreAction.NONE },
                    { TypeGesture.TAP_RIGHT, TypeScoreAction.NONE }
                };
            }
        }

    }
}