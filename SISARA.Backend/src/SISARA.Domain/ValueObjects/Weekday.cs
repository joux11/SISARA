namespace SISARA.Domain.ValueObjects
{
    public class Weekday
    {
        public string Value { get;}
        public Weekday(string value) 
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("El día de la semana no puede ser nulo o vacío", nameof(value));

            if (!new[] { "Lunes","Martes","Miercoles","Jueves", "Viernes","Sabado","Domingo"}.Contains(value))
            {
                throw new ArgumentException("El día de la semana no es válido", nameof(value));
            }
        }
        public static implicit operator string(Weekday weeday) => weeday.Value;
    }
}
