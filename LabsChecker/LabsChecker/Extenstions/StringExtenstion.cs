namespace LabsChecker.Extenstions;

internal static class StringExtenstion
{
	public static bool IsNullOrEmpty(this string? value) => string.IsNullOrEmpty(value);

	public static bool IsNotEmpty(this string? value) => !string.IsNullOrEmpty(value);

}