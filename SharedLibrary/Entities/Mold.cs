using System.ComponentModel.DataAnnotations;
using MassTransit;

namespace SharedLibrary.Entities;

/// <summary>
/// 模具
/// </summary>
public class Mold
{
    [Key]
    public NewId Id { get; set; }

    [Required]
    /// <summary>
    /// 模具钢号/厂商号
    /// </summary>
    /// <value></value>
    public string? ManufacturerPartNumber { get; set; }

    [Required]
    /// <summary>
    /// 模具编号/产品号
    /// </summary>
    /// <value></value>
    public string? ProductNumber { get; set; }

    /// <summary>
    /// 模具生产商
    /// </summary>
    /// <value></value>
    public string? ManufacturerName { get; set; }

    /// <summary>
    /// 生产日期
    /// </summary>
    /// <value></value>
    public DateOnly? DateOfProduction { get; set; }

    /// <summary>
    /// 启用日期
    /// </summary>
    /// <value></value>
    public DateOnly? DateOfActivation { get; set; }
}
