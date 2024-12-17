using System.Reflection;
using System.Text.RegularExpressions;

namespace Solutions
{
    public partial class Processor : IMyParsable<Processor>
    {
        List<int> input = new();

        Register init = new();

        [GeneratedRegex("[0-9]+")]
        private static partial Regex Number();

        List<long> output = new();

        int? jumpTo = null;

        Action<Register, int> Intructions(long input) => input switch
        {
            // adv
            0 => (Register register, int operand) => register.A = register.A >> (int)register.Combo(operand),
            // bxl
            1 => (Register register, int operand) => register.B = register.B ^ operand,
            // bst
            2 => (Register register, int operand) => register.B = register.Combo(operand) & 7,
            // jnz
            3 => (Register register, int operand) => jumpTo = register.A != 0 ? operand : null,
            // bxc
            4 => (Register register, int operand) => register.B = register.B ^ register.C,
            // out
            5 => (Register register, int operand) => output.Add(register.Combo(operand) & 7),
            // bdv
            6 => (Register register, int operand) => register.B = register.A >> (int)register.Combo(operand),
            // cdv
            7 => (Register register, int operand) => register.C = register.A >> (int)register.Combo(operand),
            // other
            _ => throw new NotSupportedException()
        };

        static Processor IMyParsable<Processor>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static Processor IMyParsable<Processor>.ParseMultiline(ICollection<string> s)
        {
            var list = s.ToList();
            return new()
            {
                init = new()
                {
                    A = long.Parse(Number().Match(list[0]).Value),
                    B = long.Parse(Number().Match(list[1]).Value),
                    C = long.Parse(Number().Match(list[2]).Value),
                },
                input = Number().Matches(list[4]).Select(x => x.Value).Select(int.Parse).ToList(),
            };
        }

        public string Run => RunA(init.A);

        string RunA(long A)
        {
            int pointer = 0;
            output = new();
            Register register = new()
            {
                A = A,
                B = 0,
                C = 0,
            };
            while (pointer < input.Count)
            {
                Intructions(input[pointer])(register, input[pointer + 1]);
                if (jumpTo.HasValue)
                {
                    pointer = jumpTo.Value;
                    jumpTo = null;
                    continue;
                }
                pointer += 2;
            }
            return string.Join(',', output);
        }

        public long FindA()
        {
            long result = 0;
            for (int i = input.Count - 1; i >= 0; i--)
            {
                result <<= 3;
                while (RunA(result) != string.Join(',', input.Skip(i)))
                    result++;
            }
            return result;
        }
    }

    public class Register
    {
        public long A, B, C;

        public long Combo(long operand)
        {
            return operand switch
            {
                <= 3 => operand,
                4 => A,
                5 => B,
                6 => C,
                _ => throw new NotSupportedException(),
            };
        }
    }
}
