# 🧠 BTG.ClientApp – Teste Técnico (.NET MAUI)

Este projeto foi desenvolvido como parte de um **teste técnico**, utilizando a tecnologia **.NET MAUI** para criar um aplicativo de cadastro de clientes com foco em:

- ✨ Boas práticas de desenvolvimento
- 📐 Princípios **SOLID**
- 🧼 Clean Architecture
- ✅ Validações de entrada e feedbacks visuais

---

## 🚀 Funcionalidades

- ✅ Cadastro de cliente
- ✅ Edição de cliente
- ✅ Remoção com confirmação
- ✅ Validações por campo (ex: `Age` só aceita números)
- ✅ Janela de formulário centralizada e com tamanho fixo
- ✅ Persistência em arquivo JSON
- ✅ Separação entre camada de UI, serviços e repositórios

---

## 🧪 Testes

A camada de lógica foi extraída para um repositório separado, permitindo testar sem dependência da UI MAUI.

> 📁 Repositório de testes:  
🔗 [`BTG.ClientApp.Tests`](https://github.com/DaniloBPeres/BTG.ClientApp.Tests)

Os testes cobrem:

- ✅ `ClientRepository` (CRUD completo)
- ✅ `ClientService` (validações e integração com o repositório)
- ✅ Teste de **integração completa** do ciclo de vida de um cliente

---

## 🖼️ Capturas de tela
### 🏠 Lista de clientes
<img width="1920" height="1036" alt="Inicio" src="https://github.com/user-attachments/assets/342d462f-f7d3-427b-bdd8-474af4c6a436" />
### 📝 Formulário de cadastro/edição
<img width="1920" height="1041" alt="Add" src="https://github.com/user-attachments/assets/34b19730-caff-4d40-925f-319340b5bcb8" />
### 📍 Janela centralizada (Windows)
<img width="1920" height="1040" alt="edit" src="https://github.com/user-attachments/assets/eab8441e-124f-4477-87f8-7618f9522c1e" />
### Excluindo Cliente
<img width="1917" height="1040" alt="Delete" src="https://github.com/user-attachments/assets/e7542e97-4fc3-4cac-b77c-fe40bb03e85b" />
### Pós Alterações
<img width="1920" height="1038" alt="pos" src="https://github.com/user-attachments/assets/1d81df50-c769-4cf7-a678-fa7ab9de1d36" />

---

## 🧰 Tecnologias utilizadas

- [.NET 9.0](https://dotnet.microsoft.com/)
- .NET MAUI
- MVVM + DI
- CommunityToolkit.Mvvm
- Json para persistência local

---

## ▶️ Como executar o projeto

1. Clone o repositório:

```bash
git clone https://github.com/DaniloBPeres/BTG.ClientApp.git
cd BTG.ClientApp
