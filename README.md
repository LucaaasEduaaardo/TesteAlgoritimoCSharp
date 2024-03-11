# Sistema de Gerenciamento de Esteira de Embalagem

Este é um sistema simples de gerenciamento de esteira de embalagem implementado em C#. Ele simula o processo de embalagem de pacotes em caixas, garantindo que cada caixa não exceda seu limite de peso.
Foram testados com pacotes de 90g a 110g e caixas de 1kg, pode ser que com valores diferentes ele possua um grande taxa de descarte dos pacotes.
## Funcionalidades

- Distribui os pacotes em caixas de acordo com seus pesos.
- Descarta os pacotes que excedem a capacidade das caixas.
- Monitora o número de pacotes descartados e caixas entregues.
- Calcula o tempo de execução do processo.

## Como Usar

1. **Preparação dos Pacotes**: No método `Main()`, você pode definir o número total de pacotes a serem processados e seus pesos. Por padrão, foi definido para 1 bilhão de pacotes com pesos aleatórios entre 90 e 110 unidades.

2. **Configuração da Esteira**: Ao instanciar a classe `Maquina`, você pode definir os pesos máximo da caixa (`pesoCaixa`) e o peso excessivo permitido (`pesoExcesso`).

3. **Execução**: Após configurar os pacotes e a esteira, basta executar o programa. Ele simulará o processo de embalagem e exibirá as estatísticas de saída.

## Pré-requisitos

- [.NET Core](https://dotnet.microsoft.com/download) instalado.

## Execução

Para compilar e executar o código:

```bash
dotnet run
```
