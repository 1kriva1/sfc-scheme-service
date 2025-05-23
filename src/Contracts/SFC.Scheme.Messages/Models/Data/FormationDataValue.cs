namespace SFC.Scheme.Messages.Models.Data;
public class FormationDataValue : DataValue
{
    public IEnumerable<FormationValueDataValue> Values { get; set; } = [];
}