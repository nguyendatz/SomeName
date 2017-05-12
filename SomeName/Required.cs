namespace SomeName
{
    public class RequiredAttribute : SomeName
    {
        public override bool IsValid(object input)
        {
            var sInput = input.ToString().Trim();
            return !string.IsNullOrEmpty(sInput);
        }
    }
}