namespace SomeName.Annotation
{
    public class RequiredAttribute : SomeName
    {
        public override bool IsValid(object[] input)
        {
            var sInput = input[0].ToString().Trim();
            return !string.IsNullOrEmpty(sInput);
        }
    }
}