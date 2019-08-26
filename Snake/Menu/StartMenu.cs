using Snake.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Models
{
    public class StartMenu : SimpleMenu
    {
        private ComplexMenu OptionsMenu;
        private int[] SelectedOptions;

        public StartMenu(List<List<string>> options) : base(options[0])
        {
            OptionsMenu = new ComplexMenu(options.Skip(1).ToList());
            SelectedOptions = OptionsMenu.SelectedOptions;
        }

        public int[] OptionSelection()
        {
            int selection;
            while (true)
            {
                DrawLogo();
                selection = StartSelecting();
                if (selection == 0)
                {
                    break;
                }
                OptionsMenu.OptionSelection();
            }
            return this.SelectedOptions;
        }        
    }
}
