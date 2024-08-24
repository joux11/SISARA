namespace SISARA.Domain.ValueObjects
{
    public class Identification
    {
        public string Value { get; private set; }

        public Identification(string value) 
        {                      

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("La cedula no puede estar vacia o nula");
            }
            if (value.Length != 10)
            {
                throw new Exception("Ingrese su cedula de 10 digitos");
            }
            if (!IsValidIdentification(value))
            {
                throw new Exception("La cedula ingresada es invalida");
            }
            Value = value;
        }
        public static implicit operator string(Identification identification) => identification.Value;
        public bool IsValidIdentification(string identification) 
        {
            bool isValid = false;

            int thirdDigit = int.Parse(identification.Substring(2, 1));
            if(thirdDigit < 6)
            {
                int[] validCoefficient = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
                int checkDigit = int.Parse(identification.Substring(9, 1));
                int sum = 0;
                for(int i = 0; i <9; i++)
                {
                    int digit = int.Parse(identification.Substring(i, 1)) * validCoefficient[i];
                    sum += (digit % 10) + (digit / 10);
                }
                int modulo = sum % 10;
                int calculatedCheckDigit = (modulo == 0) ? 0 : 10 - modulo;

                if(checkDigit == calculatedCheckDigit)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        /*public bool IsValidIdentification(string identification)
        {
            int sum = 0;
            int[] a = new int[identification.Length / 2]; 
            int[] b = new int[(identification.Length / 2)];
            int c = 0;
            int d = 1;
            for(int i = 0; i< identification.Length/2; i++)
            {
                a[i] = identification[c];
                c = c + 2;
                if(i < (identification.Length / 2) - 1)
                {
                    b[i] = identification[d];
                    d = d + 2;
                }
            }
            for(int i = 0; i<a.Length; i++)
            {
                a[i] = a[i] * 2;
                if (a[i] > 9)
                {
                    a[i] = a[i] - 9;
                }
                sum = sum + a[i] + b[i];
            }

            int aux = sum / 10;
            int dec = (aux + 1) * 10;
            if((dec-sum) == identification[identification.Length - 1])
            {
                return true;
            }
            else
            {
                if(sum %10 ==0 && identification[identification.Length - 1] == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }*/
        
    }
}
