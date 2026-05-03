# ChatAplikace
Desktopová aplikace, která umožňuje komunikaci mezi uživateli pomocí zpráv

---

## Funkce

- Registrace a přihlášení uživatele
- Vytváření chatů mezi uživateli
- Real-time posílání zpráv
- Automatická synchronizace chatů a zpráv mezi klienty
- Ukládání zpráv a chatů do databáze
- Indikátor typing u chatu

---

## Jak to funguje

- Uživatel se zaregistruje a přihlásí
- Po přihlášení vidí své chaty
- Při vytvoření nového chatu se tento chat okamžitě zobrazí oběma uživatelům
- Zprávy jsou posílány přes SignalR a ihned doručeny druhé straně
- Všechny zprávy se zároveň ukládají do databáze

---

## Architektura

- Client (WinForms)
- SignalR
- Database (EF Core)

---

## Ukázky

<img width="1773" height="532" alt="image" src="https://github.com/user-attachments/assets/739ffd75-45d6-44d4-8043-056a2e27f391" />

---

## Co projekt demonstruje

Tento projekt ukazuje:
- práci s real-time komunikací
- návrh backend logiky
- práci s databází (CRUD operace)
- autentizaci uživatelů
- asynchronní programování v C#

---

## Možná budoucí vylepšení

- online status uživatelů
- lepší UI/UX design

---

## Použité technologie

- C# (.NET / .NET Core)
- SignalR
- Entity Framework Core
- SQLite
- WinForms

---

## Autor

Tomáš Urban  
