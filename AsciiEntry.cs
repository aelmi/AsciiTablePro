using System;
using System.Globalization;

namespace AsciiTablePro
{
    public class AsciiEntry
    {
        public int Code { get; set; }
        public string Hex { get; set; }
        public string Binary { get; set; }
        public string Octal { get; set; }
        public string Char { get; set; }
        public string Unicode { get; set; }
        public string HtmlNumber { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsPrintable { get; set; }

        public static AsciiEntry Create(int code)
        {
            string hex = code.ToString("X2");
            string binary = Convert.ToString(code, 2).PadLeft(8, '0');
            string octal = Convert.ToString(code, 8).PadLeft(3, '0');
            string unicode = "U+" + code.ToString("X4");
            string htmlNumber = $"&#{code};";
            string character;
            string description;
            string category;
            bool printable = true;

            if (code < 32)
            {
                character = "";
                description = ControlCharDescription(code);
                category = "Control Character";
                printable = false;
            }
            else if (code == 127)
            {
                character = "";
                description = "Delete (DEL)";
                category = "Control Character";
                printable = false;
            }
            else if (code >= 32 && code <= 126)
            {
                character = ((char)code).ToString();
                description = PrintableCharDescription(code, character);
                category = "Printable Character";
                printable = true;
            }
            else
            {
                character = ((char)code).ToString();
                description = "Extended ASCII character";
                category = "Extended ASCII";
                printable = true;
            }

            return new AsciiEntry
            {
                Code = code,
                Hex = hex,
                Binary = binary,
                Octal = octal,
                Char = character,
                Unicode = unicode,
                HtmlNumber = htmlNumber,
                Description = description,
                Category = category,
                IsPrintable = printable
            };
        }

        private static string ControlCharDescription(int code)
        {
            // Based on ascii-code.com
            string[] names = {
                "Null char (NUL)", "Start of Heading (SOH)", "Start of Text (STX)", "End of Text (ETX)", "End of Transmission (EOT)",
                "Enquiry (ENQ)", "Acknowledge (ACK)", "Bell (BEL)", "Back Space (BS)", "Horizontal Tab (HT)",
                "Line Feed (LF)", "Vertical Tab (VT)", "Form Feed (FF)", "Carriage Return (CR)", "Shift Out (SO)", "Shift In (SI)",
                "Data Link Escape (DLE)", "Device Control 1 (DC1)", "Device Control 2 (DC2)", "Device Control 3 (DC3)",
                "Device Control 4 (DC4)", "Negative Acknowledge (NAK)", "Synchronous Idle (SYN)", "End of Transmit Block (ETB)",
                "Cancel (CAN)", "End of Medium (EM)", "Substitute (SUB)", "Escape (ESC)", "File Separator (FS)", "Group Separator (GS)",
                "Record Separator (RS)", "Unit Separator (US)"
            };
            if (code >= 0 && code < names.Length)
                return names[code];
            return "Control character";
        }

        private static string PrintableCharDescription(int code, string character)
        {
            // Based on ascii-code.com
            switch (code)
            {
                case 32: return "Space";
                case 33: return "Exclamation mark";
                case 34: return "Double quotes";
                case 35: return "Number sign";
                case 36: return "Dollar sign";
                case 37: return "Percent sign";
                case 38: return "Ampersand";
                case 39: return "Single quote";
                case 40: return "Left parenthesis";
                case 41: return "Right parenthesis";
                case 42: return "Asterisk";
                case 43: return "Plus sign";
                case 44: return "Comma";
                case 45: return "Hyphen";
                case 46: return "Period";
                case 47: return "Slash";
                case 58: return "Colon";
                case 59: return "Semicolon";
                case 60: return "Less-than";
                case 61: return "Equals sign";
                case 62: return "Greater-than";
                case 63: return "Question mark";
                case 64: return "At sign";
                case 91: return "Left square bracket";
                case 92: return "Backslash";
                case 93: return "Right square bracket";
                case 94: return "Caret";
                case 95: return "Underscore";
                case 96: return "Grave accent";
                case 123: return "Left curly brace";
                case 124: return "Vertical bar";
                case 125: return "Right curly brace";
                case 126: return "Tilde";
                default:
                    if (code >= 48 && code <= 57) return $"Digit {character}";
                    if (code >= 65 && code <= 90) return $"Uppercase letter {character}";
                    if (code >= 97 && code <= 122) return $"Lowercase letter {character}";
                    return "Printable character";
            }
        }
    }
}