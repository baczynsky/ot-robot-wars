using System.Text.RegularExpressions;

namespace RoboWars.Game.Commands
{
    public static class CommandValidator
    {
        private const string ArenaInitialiseRegexPattern = @"^[0-9]+\s+[0-9]+\s*$";
        private const string RobotInitialiseRegexPattern = @"^[0-9]+\s+[0-9]+\s+[NESW]\s*$";
        private const string RobotMoveRegexPattern = @"^[LRM]+$";

        public static bool IsValidInitialiseCommand(this string cmd)
        {
            return Regex.IsMatch(cmd, ArenaInitialiseRegexPattern)
                    || Regex.IsMatch(cmd, RobotInitialiseRegexPattern);
        }

        public static bool IsValidMoveCommand(this string cmd)
        {
            return Regex.IsMatch(cmd, RobotMoveRegexPattern);
        }
    }
}
