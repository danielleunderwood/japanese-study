namespace Core;

public class Verb
{
	public string PlainForm { get; set; }
	public VerbType Type { get; set; }
	public IrregularConjugations IrregularConjugations { get; set; }

	public static bool operator ==(Verb a, Verb b)
	{
		return a.PlainForm == b.PlainForm;
	}

	public static bool operator !=(Verb a, Verb b)
	{
		return !(a == b);
	}

	public override bool Equals(object obj)
	{
		return this == (Verb)obj;
	}

	public override int GetHashCode()
	{
		return PlainForm.GetHashCode();
	}
}
