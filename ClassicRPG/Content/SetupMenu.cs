namespace ClassicRPG.Content
{
    static class SetupMenu
    {
        public static MenuActionResult CreateMenu() => new MenuActionResult
        {
            Text = "Добро пожаловать в текстовую RPG.",
            AvailableActions =
                {
                    new MenuAction
                    {
                        Key = '1',
                        Text = "Новая игра",
                        Result = new GameActionResult
                        {
                            Text = "Началась игра",
                            Do = (gs) =>
                            {
                                gs.Reset();
                                gs.Character.Display();
                            }
                        }
                    },

                    new MenuAction
                    {
                        Key = '2',
                        Text = "Выход",
                        Result = new MenuActionResult
                        {
                            Do = gs => gs.IsPlaying = false,
                        }
                    }
                }
        };
    }
}
