namespace KentriosiPhotosContests.Common
{
    using System.Reflection;

    public interface IAssemblyHelper
    {
        string GetDirectoryForAssembly(Assembly assembly);
    }
}
