using static Business.MtgLifeCounter.Enumerations.Enum;

namespace Business.MtgLifeCounter.Gesture
{
    public class GestureReport
    {
        public TypeScore TypeScore { get; set; }
        public TypeZone TypeZone { get; set; }
        public TypePlayer TypePlayer { get; set; }
        public TypeGesture TypeGesture { get; set; }
    }
}