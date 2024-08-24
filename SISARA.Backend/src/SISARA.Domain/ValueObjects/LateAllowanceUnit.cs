namespace SISARA.Domain.ValueObjects
{
    public class LateAllowanceUnit
    {
        public string Value { get; }
        public LateAllowanceUnit(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("No puede ser nulo o valido", nameof(value));
            if (!new[] {"Minutos","Horas"}.Contains(value)) throw new ArgumentException("La unidad de tolerancia no es válida", nameof(value));

        }
        public static implicit operator string(LateAllowanceUnit allowedLateTime) => allowedLateTime.Value;
    }
}
