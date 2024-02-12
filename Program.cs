using System;
using System.Diagnostics;

public class Maquina
{   
    private int qtdPacotesDescartados = 0;
    private int caixasEntregues = 0;
    public void Esteira(
        // int totalPacotes,
        int[] pesosPacotes,
        int pesoCaixa,
        int pesoExcesso
    ){
        Caixa[] caixas =
        [
            new Caixa(pesoCaixa, pesoExcesso), // 1
            new Caixa(pesoCaixa, pesoExcesso), // 2
            new Caixa(pesoCaixa, pesoExcesso), // 3
            new Caixa(pesoCaixa, pesoExcesso), // 4
            new Caixa(pesoCaixa, pesoExcesso), // 5
            new Caixa(pesoCaixa, pesoExcesso), // 6
        ];
        
        int indexPacote = 0;
        foreach (double pacote in pesosPacotes)
        {   
            // Console.WriteLine("pacote => "+indexPacote+" | peso => " + pacote);
            int indexCaixa = 0;
            int indexDecartPacote = 0;
            foreach (var caixa in caixas)
            {
                if(caixa.GetPesoInterno() >= caixa.GetPesoCaixa()){
                    caixa.LiberarCaixa();
                    caixasEntregues += 1;
                }

                if(caixa.AddPeso(pacote)){
                    // Console.WriteLine("caixa => "+indexCaixa+"| peso => "+ caixa.GetPesoInterno());
                    break;
                } else {
                    indexDecartPacote += 1;
                }

                indexCaixa += 1;
            }
            if(indexDecartPacote >= 6){
                qtdPacotesDescartados += 1;
                // Console.WriteLine("pacote descartado => " + pacote);
            }
            indexPacote += 1;
        }
        int idx = 0;
        int qtdPacotesss = qtdPacotesDescartados;
        foreach (var caixa in caixas)
        {
            Console.WriteLine("caixa => "+idx+" | qtd pacote => "+ caixa.GetQtdPacotes() + " | peso => "+ caixa.GetPesoInterno());
            qtdPacotesss += caixa.GetQtdPacotes();
            idx += 1;
        }
        Console.WriteLine($"Pacotes Descartados => {qtdPacotesss}" + "| total => " + indexPacote);
        Console.WriteLine("Caixas entregues => " + caixasEntregues);
    }
}

public class Caixa 
{
    private double pesoInterno;
    private double pesoCaixa;
    private int quantidadeDePacotes;
    private double pesoExcesso;

    private int CaixaReset;
    public Caixa(double peso, double pesoEx)
    {
        pesoCaixa = peso;
        pesoExcesso = pesoEx;
    }

    public double GetPesoCaixa(){
        return pesoCaixa;
    }

    public double GetMaxPesoCaixa(){
        return pesoCaixa + pesoExcesso;
    }

    public int GetQtdPacotes(){
        return quantidadeDePacotes;
    }

    public double GetPesoInterno()
    {
        return pesoInterno;
    }

    public bool AddPeso(double peso)
    {
        double pesoTotal = pesoInterno + peso;
        
        if (pesoTotal <= pesoCaixa + pesoExcesso)
        {
            pesoInterno = pesoTotal;
            quantidadeDePacotes += 1;
            return true;
        }
        return false;
    }

    public int GetCaixaReset(){
        return CaixaReset;
    }
    public int LiberarCaixa(){
        CaixaReset += 1;
        pesoInterno = 0;
        quantidadeDePacotes = 0;

        return GetQtdPacotes();
    }
}


// public class Numeros
// {
//     public static int[] retornaNumeros()
//     {   
//         // cada linha tem 100 valores
//         return new int[] {
//             101, 105, 108, 103, 92, 94, 100, 97, 109, 102, 96, 107, 110, 105, 103, 98, 106, 109, 101, 104, 98, 107, 106, 103, 96, 104, 101, 100, 93, 97, 94, 103, 109, 104, 95, 96, 108, 100, 105, 107, 98, 94, 100, 101, 102, 110, 95, 102, 108, 110, 105, 97, 100, 101, 96, 107, 93, 102, 108, 107, 101, 99, 100, 101, 100, 104, 107, 95, 96, 108, 103, 107, 100, 93, 104, 99, 97, 98, 101, 102, 97, 98, 99, 100, 108, 102, 107, 101, 93, 108, 105, 94, 97, 107, 95, 98, 110, 97, 94, 102
//         };
//     }
// }

class Program
{   
    static void Main()
    {   
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // int[] pesosPacotes = Numeros.retornaNumeros();

        int totalPacotes = 1000000000; 
        int[] pesosPacotes = new int[totalPacotes];
        Random rand = new Random(); 
        for (int i = 0; i < totalPacotes; i++)
        {
            int peso = rand.Next(90, 111); 
            pesosPacotes[i] = peso; 
        }
        Maquina maquina = new Maquina();
        // totalPacotes,
        maquina.Esteira(pesosPacotes, 1000, 100);
        stopwatch.Stop();
        Console.WriteLine($"Tempo de execução: {stopwatch.ElapsedMilliseconds} ms");
        
    }
}
