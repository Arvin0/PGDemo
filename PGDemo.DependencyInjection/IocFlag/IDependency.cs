namespace PGDemo.DependencyInjection.IocFlag
{
    /// <summary>
    /// 自动注入标识,默认是scope
    /// </summary>
    public interface IDependency
    {
    }

    /// <summary>
    /// 自动注入标识: Singleton
    /// </summary>
    public interface ISingletonDependency
    {

    }

    /// <summary>
    /// 自动注入标识: Scope
    /// </summary>
    public interface IScopeDependency
    {

    }

    /// <summary>
    /// 自动注入标识: Transient
    /// </summary>
    public interface ITransientDependency
    {

    }
}
