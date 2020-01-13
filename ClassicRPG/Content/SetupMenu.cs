using ClassicRPG.Character;

namespace ClassicRPG.Content
{
    static class SetupMenu
    {
        public static ActionResult CreateMenu() => new ActionResult
        {
            Text = "Добро пожаловать в текстовую RPG.",
            AvailableActions =
            {
                new Action
                {
                    Key = '1',
                    Text = "Новая игра",
                    Result = new ActionResult
                    {
                        Text = Texts.NewGame1,
                        Do = (gs) =>
                        {
                            gs.Reset();
                        },
                        AvailableActions =
                        {
                            new Action
                            {
                                Key = '1',
                                Text = $"Узнать о классе '{new Warrior().DisplayName}'",
                                Result = new ActionResult
                                {
                                    Text = "Воин это воин"
                                }
                            },

                            new Action
                            {
                                Key = '2',
                                Text = $"Узнать о классе '{new Scoundrel().DisplayName}'",
                                Result = new ActionResult
                                {
                                    Text = "Разбойник это разбойник"
                                }
                            },

                            new Action
                            {
                                Key = '3',
                                Text = $"Узнать о классе '{new Mage().DisplayName}'",
                                Result = new ActionResult
                                {
                                    Text = "Маг это маг"
                                }
                            },
                        }
                    }
                },

                new Action
                {
                    Key = '2',
                    Text = "Выход",
                    Result = new ActionResult
                    {
                        Do = gs => gs.IsPlaying = false,
                    }
                }
            }
        };
    }
}
