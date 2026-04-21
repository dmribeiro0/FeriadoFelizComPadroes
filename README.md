> Obs: Esse projeto é uma simulação de um sistema de pedidos para redes de restaurantes, focado em demonstrar a aplicação de múltiplos padrões de projeto (Factory, Decorator, Facade, Strategy e Observer). Foi desenvolvido durante a disciplina de Projeto Orientado a Objeto na Universidade Federal de São Paulo (UNIFESP - SJC).

# FoodOrderingSystem

Este projeto simula um sistema de pedidos para duas redes de restaurante (McDonald's e Burger King), com montagem de itens, combos, fechamento de pedido e pagamento.

O foco principal é demonstrar a composição de múltiplos padrões de projeto em um fluxo único.

## Visão Geral da Arquitetura

O fluxo principal está em `Program.cs`:

1. Cria um sistema de pedidos (`McDOrderingSystem` ou `BKOrderingSystem`).
2. Exibe menu.
3. Adiciona itens ao pedido (incluindo combos).
4. Exibe pedido atual.
5. Define forma de pagamento (`IPaymentMethod`).
6. Fecha pedido e executa pagamento.

As classes de restaurante montam o cardápio com itens básicos, itens decorados e combos. O pagamento usa strategy + observer para notificar mudanças de status.

## Como os Padrões Foram Implementados

### 1) Factory

- `Factory/RestaurantFactory.cs` implementa uma fábrica simples para criar `IRestaurant` com base em string (`"mcdonald's"` ou `"burger king"`).
- `Factory/IRestaurant.cs` define o contrato comum de restaurantes (`SetMenu` e `GetMenu`).

Observação: no estado atual, `Program.cs` instancia diretamente `McDOrderingSystem` e `BKOrderingSystem`; a `RestaurantFactory` fica disponível como alternativa de criação.

### 2) Decorator

- `Decorator/IMenuItem.cs` define o contrato (`GetPrice`).
- `Decorator/MenuItemDecorator.cs` é o decorador base (envolve outro `IMenuItem`).
- Em `Decorator/BaseItems/*.cs` estão os itens básicos (hambúrguer, batata, bebidas).
- Em `Decorator/Decorators/*.cs` estão os adicionais (queijo extra, bacon, salada, etc.), cada um somando valor ao item decorado.

Exemplo de composição:

- Big Mac: `new ExtraBun(new ExtraCheese(new ExtraPatty(new CheeseBurger())))`
- Whopper Bacon: `new Bacon(new ExtraCheese(new Salad(new CheeseBurger())))`

### 3) Facade

- `Facade/ComboFacade.cs` simplifica a criação de combos com métodos estáticos:
	- `CreateCombo(mainCourse, side, drink)`
	- `CreateCustomCombo(items)`
- `Facade/Combo.cs` representa o combo como um `IMenuItem`, acumulando o preço dos itens.

Assim, o restante do sistema adiciona combos ao menu e ao pedido sem conhecer os detalhes de composição.

### 4) Strategy

- `Strategy/IPaymentMethod.cs` define a estratégia de pagamento.
- Implementações:
	- `Strategy/CreditCardPayment.cs`
	- `Strategy/DebitCardPayment.cs`
	- `Strategy/PixPayment.cs`

Cada estratégia processa o pagamento de forma intercambiável e emite status através de `PaymentStatus`.

### 5) Observer

- `Observer/PaymentSubject.cs` mantém lista de observadores e notifica todos.
- `Observer/IPaymentObserver.cs` define o contrato de observador.
- `Observer/PaymentObserver.cs` imprime mudanças de status no console.
- `Observer/PaymentStatus.cs` herda de `PaymentSubject` e dispara notificações a cada alteração de status.

No fluxo, a estratégia de pagamento recebe um observador via `SetObserver` e, durante `Pay`, atualiza o `PaymentStatus` (ex.: "Processing payment." e "Payment processed.").

## Conexão Entre Arquivos (Mapa Completo)

### Raiz

| Arquivo | Papel | Conexões principais |
|---|---|---|
| `Program.cs` | Script de teste/smoke test do fluxo completo | Usa `IOrderingSystem`, `McDOrderingSystem`, `BKOrderingSystem`, `IPaymentMethod`, `CreditCardPayment`, `PixPayment` |
| `FoodOrderingSystem.csproj` | Configuração do projeto .NET | Define `net9.0`, nullable e output executável |

### Core

| Arquivo | Papel | Conexões principais |
|---|---|---|
| `Core/IOrderingSystem.cs` | Contrato do fluxo de pedido | Referenciado por `Program.cs`, implementado por `BKOrderingSystem` e `McDOrderingSystem` |
| `Core/BKOrderingSystem.cs` | Orquestra fluxo de pedido Burger King | Usa `IRestaurant` (`BurgerKing`), `Menu`, `IMenuItem`, `IPaymentMethod`, `IPaymentObserver`, `PaymentObserver` |
| `Core/McDOrderingSystem.cs` | Orquestra fluxo de pedido McDonald's | Usa `IRestaurant` (`McDonalds`), `Menu`, `IMenuItem`, `IPaymentMethod`, `IPaymentObserver`, `PaymentObserver` |

### Factory

| Arquivo | Papel | Conexões principais |
|---|---|---|
| `Factory/IRestaurant.cs` | Interface para restaurantes concretos | Implementada por `McDonalds` e `BurgerKing`; usada pelos OrderingSystems |
| `Factory/RestaurantFactory.cs` | Factory para criar `IRestaurant` por nome | Instancia `McDonalds` e `BurgerKing` |
| `Factory/McDonalds.cs` | Monta o menu do McDonald's | Usa `Menu`, itens base, decorators e `ComboFacade` |
| `Factory/BurgerKing.cs` | Monta o menu do Burger King | Usa `Menu`, itens base, decorators e `ComboFacade` |

### Decorator (infra)

| Arquivo | Papel | Conexões principais |
|---|---|---|
| `Decorator/IMenuItem.cs` | Contrato para qualquer item vendável | Base para itens simples, decorados e combos |
| `Decorator/MenuItemDecorator.cs` | Classe base para decorators | Herdada por classes de `Decorator/Decorators` |
| `Decorator/Menu.cs` | Catálogo de itens (`nome -> fábrica`) | Usado por `McDonalds`, `BurgerKing` e OrderingSystems |

### Decorator/BaseItems

| Arquivo | Papel |
|---|---|
| `Decorator/BaseItems/CheeseBurger.cs` | Item básico hambúrguer |
| `Decorator/BaseItems/Fries.cs` | Item básico batata |
| `Decorator/BaseItems/Coke.cs` | Item básico refrigerante |
| `Decorator/BaseItems/Milkshake.cs` | Item básico milkshake |
| `Decorator/BaseItems/GuaranaAntarctica.cs` | Item básico guaraná |

Todos implementam `IMenuItem` e são usados na montagem de itens e combos.

### Decorator/Decorators

| Arquivo | Papel |
|---|---|
| `Decorator/Decorators/ExtraPatty.cs` | Adiciona hambúrguer extra |
| `Decorator/Decorators/ExtraCheese.cs` | Adiciona queijo extra |
| `Decorator/Decorators/ExtraBun.cs` | Adiciona pão extra |
| `Decorator/Decorators/Bacon.cs` | Adiciona bacon |
| `Decorator/Decorators/Salad.cs` | Adiciona salada |
| `Decorator/Decorators/Chocolate.cs` | Adiciona chocolate |
| `Decorator/Decorators/Strawberry.cs` | Adiciona morango |
| `Decorator/Decorators/LemonSlice.cs` | Adiciona fatia de limão |
| `Decorator/Decorators/OrangeSlice.cs` | Adiciona fatia de laranja |
| `Decorator/Decorators/Ice.cs` | Adiciona gelo |

Esses decorators são encadeados nos restaurantes para criar produtos compostos.

### Facade

| Arquivo | Papel | Conexões principais |
|---|---|---|
| `Facade/Combo.cs` | Representa combo como `IMenuItem` | Recebe múltiplos `IMenuItem` |
| `Facade/ComboFacade.cs` | API simplificada para criar combos | Usada por `McDonalds` e `BurgerKing` |

### Strategy

| Arquivo | Papel | Conexões principais |
|---|---|---|
| `Strategy/IPaymentMethod.cs` | Interface de estratégia de pagamento | Usada por OrderingSystems |
| `Strategy/CreditCardPayment.cs` | Estratégia pagamento no crédito | Usa `PaymentStatus` e observer anexado |
| `Strategy/DebitCardPayment.cs` | Estratégia pagamento no débito | Usa `PaymentStatus` e observer anexado |
| `Strategy/PixPayment.cs` | Estratégia pagamento via Pix | Usa `PaymentStatus` e observer anexado |

### Observer

| Arquivo | Papel | Conexões principais |
|---|---|---|
| `Observer/IPaymentObserver.cs` | Contrato do observador | Implementado por `PaymentObserver` |
| `Observer/PaymentObserver.cs` | Observador concreto (log de status) | Recebe notificações de `PaymentSubject` |
| `Observer/PaymentSubject.cs` | Sujeito observável (attach/detach/notify) | Classe base de `PaymentStatus` |
| `Observer/PaymentStatus.cs` | Estado do pagamento + disparo de eventos | Chamado pelas estratégias de pagamento |

## Fluxo de Execução Passo a Passo

1. `Program.cs` chama `RunOrderingFlow` para cada restaurante.
2. `BKOrderingSystem`/`McDOrderingSystem` usam o restaurante concreto para acessar `Menu`.
3. O menu retorna novos `IMenuItem` via `Func<IMenuItem>`.
4. Itens podem ser simples (BaseItems), decorados (Decorator) ou combos (Facade).
5. Ao fechar pedido, o OrderingSystem calcula total e chama `IPaymentMethod.Pay(total)`.
6. A estratégia de pagamento atualiza `PaymentStatus`.
7. `PaymentStatus` notifica observadores (`PaymentObserver`), que exibem o status.

## Como Executar

No diretório `FoodOrderingSystem`:

```bash
dotnet build
dotnet run
```

## Observações de Design

- O sistema já está preparado para adicionar novos restaurantes (`IRestaurant` + `RestaurantFactory`).
- Novos adicionais podem ser criados sem alterar itens base (Decorator).
- Novos tipos de pagamento entram implementando `IPaymentMethod` (Strategy).
- O canal de notificação de pagamento pode crescer com novos observadores (Observer).
- A criação de combos permanece simples para o cliente via `ComboFacade` (Facade).
