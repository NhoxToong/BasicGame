using System;

namespace game
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using (var game = new Game1())
            {
                using (Config cfg = Config.Instance)
                {
                    cfg.Load();
                    game.Run();
                    cfg.Save();
                }
            }
        }
    }
#endif
}
