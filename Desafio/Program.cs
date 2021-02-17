using System;
using System.Globalization;

class minhaClasse {
    static void Main(string[] args) { 
        double salario = 0.00;
        
        salario = double.Parse(Console.ReadLine().Replace(",","."), CultureInfo.InvariantCulture);

        if (salario < 0.00) {
            return;
        }
        else if (salario >= 0.00 && salario <= 400.00) {
            CalcularReajuste(salario, 0.15);
        }
        else if (salario > 400.00 && salario <= 800.00) {
            CalcularReajuste(salario, 0.12);
        }
        else if (salario > 800.00 && salario <= 1200.00) {
            CalcularReajuste(salario, 0.10);
        }
        else if (salario > 1200.00 && salario <= 2000.00) {
            CalcularReajuste(salario, 0.07);
        }
        else {
            CalcularReajuste(salario, 0.04);
        }
    }

    private static void CalcularReajuste(double salario, double perc) {
        double novoSalario = 0.00;
        double reajuste = 0.00;
        double percentual = 0.00;

        if (salario == 0.00) {
            reajuste = 0.00;
            novoSalario = 0.00;
            percentual = 15;
        }
        else {
            reajuste = salario * perc;
            novoSalario = salario + reajuste;
            percentual = ((novoSalario - salario) * 100) / salario;
        }

        Console.WriteLine("Novo salario: {0}",  novoSalario.ToString("F2", CultureInfo.InvariantCulture));
        Console.WriteLine("Reajuste ganho: {0}", reajuste.ToString("F2", CultureInfo.InvariantCulture));
        Console.WriteLine("Em percentual: {0:0} %", percentual);
    }
}