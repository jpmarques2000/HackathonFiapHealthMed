using Bogus;
using Hackathon.HealthMed.Services.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Tests.FakeData
{
    public class DoctorUpdateInputFaker : Faker<DoctorUpdateInput>
    {
        public DoctorUpdateInputFaker()
        {
            RuleFor(c => c.Id, f => f.Random.Int(1, 99999999));
            RuleFor(c => c.CPF, f => GenerateCPF());
            RuleFor(c => c.Name, f => f.Random.Word());
            RuleFor(c => c.CRM, f => GenerateCodigoCRM());
        }
        public static string GenerateCPF()
        {
            Random rand = new Random();
            int[] cpf = new int[11];
            for (int i = 0; i < 9; i++)
            {
                cpf[i] = rand.Next(0, 9);
            }

            cpf[9] = CalculateDigit(cpf, 9);
            cpf[10] = CalculateDigit(cpf, 10);

            return string.Join("", cpf);
        }

        private static int CalculateDigit(int[] cpf, int length)
        {
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += cpf[i] * (length + 1 - i);
            }

            int remainder = sum % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }

        public static string GenerateCodigoCRM()
        {
            Random rand = new Random();
            return $"CRM-{rand.Next(1000, 9999)}-{rand.Next(1000, 9999)}";
        }
    }
}
