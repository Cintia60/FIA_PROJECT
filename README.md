# Pac-Man: Comportamento dos Fantasmas

## Introdução

Este projeto simula o comportamento dos quatro fantasmas principais do jogo **Pac-Man**: Blinky, Pinky, Inky e Clyde. Utilizando o Unity, os fantasmas reagem ao ambiente de acordo com suas percepções e implementam diferentes estratégias de movimento.

Os fantasmas têm comportamentos distintos, como perseguir, emboscar, agir aleatoriamente ou fugir. O objetivo deste trabalho é modelar essas ações de forma que cada fantasma tome decisões baseadas nas suas percepções sobre o ambiente do jogo.

## Comportamento dos Fantasmas

### 1. Blinky (O Perseguidor)
- **Comportamento**: Blinky persegue diretamente o Pac-Man, tentando minimizar a distância entre eles.
- **Percepções Necessárias**: Direções relativas ao Pac-Man (Norte, Oeste, Este, Sul).
- **Ação**: Move-se na direção do Pac-Man, verificando as células adjacentes e escolhendo o movimento mais direto.

### 2. Pinky (O Emboscador)
- **Comportamento**: Pinky tenta emboscar o Pac-Man, movendo-se para uma posição à frente dele.
- **Percepções Necessárias**: Direções relativas ao Pac-Man, distâncias em várias direções (Norte, Oeste, Este, Sul).
- **Ação**: Move-se para a posição calculada à frente do Pac-Man.

### 3. Inky (O Errático)
- **Comportamento**: Inky exibe um comportamento aleatório, escolhendo uma direção de forma arbitrária.
- **Percepções Necessárias**: Informações sobre as paredes nas direções Norte, Oeste, Este, Sul.
- **Ação**: Escolhe aleatoriamente uma direção válida para se mover.

### 4. Clyde (O Fugitivo)
- **Comportamento**: Clyde tenta manter a maior distância possível dos outros fantasmas.
- **Percepções Necessárias**: Direções relativas aos outros fantasmas (Norte, Oeste, Este, Sul).
- **Ação**: Escolhe a direção que maximiza a distância dos fantasmas mais próximos.

## Sistema de Produções

O comportamento dos fantasmas é modelado através de um sistema de produções implementado no Unity. As regras do sistema de produções são baseadas nas percepções do ambiente e são usadas para determinar a ação de cada fantasma.

Exemplos de regras para Blinky:

- **PacManNorth**: Se o Pac-Man está ao sul e a leste, Blinky se move para o sul, leste ou oeste.
- **PacManEast**: Se o Pac-Man está ao norte, Blinky tenta se mover para o sul, oeste ou leste, dependendo das condições.

Além disso, os comportamentos dos outros fantasmas seguem um padrão semelhante, com regras definidas para as suas percepções específicas.


## Requisitos

- **Unity 2020 ou superior**.
- **C#**: Linguagem utilizada para o desenvolvimento dos scripts.

## Como Rodar

1. Clone este repositório:
   ```bash
   git clone https://github.com/usuário/pacman-fantasmas.git
