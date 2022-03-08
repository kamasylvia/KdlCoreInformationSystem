using System.ComponentModel.DataAnnotations;
using MassTransit;
using SharedResources.Enums;

namespace SharedResources.Entities;

/// <summary>
/// 产品
/// </summary>
public class Product
{
    [Key]
    public NewId Id { get; set; }

    /// <summary>
    /// 产品名称
    /// </summary>
    /// <value></value>
    public string? Name { get; set; }

    /// <summary>
    /// 产品种类
    /// </summary>
    /// <value></value>
    public ProductCategory ProductCategory { get; set; }

    /// <summary>
    /// 产品代码
    /// </summary>
    /// <value></value>
    public string? ProductCode { get; set; }
}
