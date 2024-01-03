using LabsChecker.Models;

namespace LabsChecker.Extenstions;

internal static class LabWorkExtenstions
{
	public static LabWorkCheckBlockModel Copy(this LabWorkCheckBlockModel model)
	{
		return new()
		{
			Id = Guid.NewGuid(),
			BlockTitle = model.BlockTitle,
			Items = model.Items.Select(x => x.Copy()).ToList()
		};
	}

	public static LabWorkCheckItemModel Copy(this LabWorkCheckItemModel model)
	{
		return new()
		{
			Id = Guid.NewGuid(),
			Requirement = model.Requirement,
			CheckList = model.CheckList,
			ErrorList = model.ErrorList.Select(x => x).ToList()
		};
	}
}