using System.Text.RegularExpressions;

namespace PhonebookService.Domain.Validators;

/// <summary>
/// Validator for Zip/postal codes (worldwide)
/// </summary>
public class ZipCodeValidator
{
	// https://stackoverflow.com/questions/578406/what-is-the-ultimate-postal-code-and-zip-regex
	// TODO: Sort by popularity to improve efficiency
	private readonly string[] patterns = new string[70]
	{
		@"^GIR[ ]?0AA|((AB|AL|B|BA|BB|BD|BH|BL|BN|BR|BS|BT|CA|CB|CF|CH|CM|CO|CR|CT|CV|CW|DA|DD|DE|DG|DH|DL|DN|DT|DY|E|EC|EH|EN|EX|FK|FY|G|GL|GY|GU|HA|HD|HG|HP|HR|HS|HU|HX|IG|IM|IP|IV|JE|KA|KT|KW|KY|L|LA|LD|LE|LL|LN|LS|LU|M|ME|MK|ML|N|NE|NG|NN|NP|NR|NW|OL|OX|PA|PE|PH|PL|PO|PR|RG|RH|RM|S|SA|SE|SG|SK|SL|SM|SN|SO|SP|SR|SS|ST|SW|SY|TA|TD|TF|TN|TQ|TR|TS|TW|UB|W|WA|WC|WD|WF|WN|WR|WS|WV|YO|ZE)(\d[\dA-Z]?[ ]?\d[ABD-HJLN-UW-Z]{2}))|BFPO[ ]?\d{1,4}$",
		@"^JE\d[\dA-Z]?[ ]?\d[ABD-HJLN-UW-Z]{2}$",
		@"^GY\d[\dA-Z]?[ ]?\d[ABD-HJLN-UW-Z]{2}$",
		@"^IM\d[\dA-Z]?[ ]?\d[ABD-HJLN-UW-Z]{2}$",
		@"^\d{5}([ \-]\d{4})?$",
		@"^[ABCEGHJKLMNPRSTVXY]\d[ABCEGHJ-NPRSTV-Z][ ]?\d[ABCEGHJ-NPRSTV-Z]\d$",
		@"^\d{5}$",
		@"^\d{3}-\d{4}$",
		@"^\d{2}[ ]?\d{3}$",
		@"^\d{4}$",
		@"^\d{4}[ ]?[A-Z]{2}$",
		@"^\d{3}[ ]?\d{2}$",
		@"^\d{5}[\-]?\d{3}$",
		@"^\d{4}([\-]\d{3})?$",
		@"^22\d{3}$",
		@"^\d{3}[\-]\d{3}$",
		@"^\d{6}$",
		@"^\d{3}(\d{2})?$",
		@"^AD\d{3}$",
		@"^([A-HJ-NP-Z])?\d{4}([A-Z]{3})?$",
		@"^(37)?\d{4}$",
		@"^((1[0-2]|[2-9])\d{2})?$",
		@"^(BB\d{5})?$",
		@"^[A-Z]{2}[ ]?[A-Z0-9]{2}$",
		@"^BBND 1ZZ$",
		@"^[A-Z]{2}[ ]?\d{4}$",
		@"^\d{7}$",
		@"^\d{4,5}|\d{3}-\d{4}$",
		@"^([A-Z]\d{4}[A-Z]|(?:[A-Z]{2})?\d{6})?$",
		@"^\d{3}$",
		@"^39\d{2}$",
		@"^(?:\d{5})?$",
		@"^(\d{4}([ ]?\d{4})?)?$",
		@"^(948[5-9])|(949[0-7])$",
		@"^[A-Z]{3}[ ]?\d{2,4}$",
		@"^(\d{3}[A-Z]{2}\d{3})?$",
		@"^980\d{2}$",
		@"^((\d{4}-)?\d{3}-\d{3}(-\d{1})?)?$",
		@"^(\d{6})?$",
		@"^(PC )?\d{3}$",
		@"^\d{2}-\d{3}$",
		@"^00[679]\d{2}([ \-]\d{4})?$",
		@"^4789\d$",
		@"^00120$",
		@"^96799$",
		@"^6799$",
		@"^8\d{4}$",
		@"^6798$",
		@"^FIQQ 1ZZ$",
		@"^2899$",
		@"^(9694[1-4])([ \-]\d{4})?$",
		@"^9[78]3\d{2}$",
		@"^9[78][01]\d{2}$",
		@"^SIQQ 1ZZ$",
		@"^969[123]\d([ \-]\d{4})?$",
		@"^969[67]\d([ \-]\d{4})?$",
		@"^9695[012]([ \-]\d{4})?$",
		@"^9[78]2\d{2}$",
		@"^988\d{2}$",
		@"^008(([0-4]\d)|(5[01]))([ \-]\d{4})?$",
		@"^987\d{2}$",
		@"^9[78]5\d{2}$",
		@"^PCRN 1ZZ$",
		@"^96940$",
		@"^9[78]4\d{2}$",
		@"^(ASCN|STHL) 1ZZ$",
		@"^[HLMS]\d{3}$",
		@"^TKCA 1ZZ$",
		@"^986\d{2}$",
		@"^976\d{2}$"
	};

	public bool IsValid(string input)
	{
		if (input is null)
			return false;

		input = input.Trim();

		for (int i = 0; i < patterns.Length; i++)
			if (Regex.IsMatch(input, patterns[i], RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(500)))
				return true;

		return false;
	}
}
