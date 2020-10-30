using FlatGalaxySociety.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class HttpImporter : Importer
    {
        public override string OpenPrompt()
        {
            TextInputWindow inputWindow = new TextInputWindow();
            var result = inputWindow.ShowDialog();

            if (result.HasValue && result.Value)
            {
                var vm = (TextInputViewModel)inputWindow.DataContext;
                bool isUri = Uri.IsWellFormedUriString(vm.CustomInput, UriKind.RelativeOrAbsolute);
                if (isUri)
                {
                    return vm.CustomInput;
                }
            }
            throw new InvalidInputException("Invoer in niet geldig");
        }

        public override string PrependType(string path)
        {
            return $"http{path}";
        }
    }
}