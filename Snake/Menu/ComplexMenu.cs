using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Models
{
    public class ComplexMenu:SimpleMenu
    {
        public int[] SelectedOptions { get; }
        private List<SimpleMenu> Menus;

        public ComplexMenu(List<List<string>> menues) : base(menues[0])
        {
            Menus = new List<SimpleMenu>();
            foreach (var menu in menues.Skip(1))
            {
                Menus.Add(new SimpleMenu(menu));
            }
            SelectedOptions = new int[Menus.Count];
            for (int i = 0; i < SelectedOptions.Length; i++)
            {
                SelectedOptions[i] = -1;
            }
            Options.Add( stringToKeyValue("Done"));
        }

        public int[] OptionSelection()
        {
            int selection;
            while (true)
            {
                selection = StartSelecting();
                if (selection == Options.Count-1)
                {
                    break;
                }
                SelectedOptions[selection] = Menus[selection].StartSelecting();
            }
            return SelectedOptions;
        }
    }
}
