using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLingo.Dto
{
    public class TranslationResult
    {
        public DetectedLanguage DetectedLanguage {  get; set; }
        public Translation[] Translations { get; set; }
    }
}
