namespace Rr.Solutions.Grm.Data.Abstraction.Converters
{
	public interface IEntityConverter<out T>
	{
		T GetEntity(string[] data);
	}
}
