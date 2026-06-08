# 🔤 Word Scramble Game

A fun and educational Windows Forms desktop application where players unscramble letters to form correct words. Test your vocabulary skills and challenge yourself with hundreds of words!

## 🎮 Game Features

- **Random Word Generation** - Each game picks a random word from a list of 500+ words
- **Scrambled Word Puzzles** - Letters are shuffled using the Fisher-Yates algorithm
- **Progress Tracking** - Keeps count of:
  - Correct guesses
  - Failed attempts per word
  - Total words guessed
- **Auto-Skip Feature** - After 10 failed attempts, automatically moves to a new word
- **Skip Button** - Skip any word you find too difficult
- **Visual Feedback** - Background color changes as you get closer to the attempt limit:
  - 🟢 0-3 attempts: Gray background
  - 🟡 4-6 attempts: Yellow background
  - 🔴 7-9 attempts: Salmon background
- **Keyboard Support** - Press **Enter** to submit your guess (no clicking needed!)


## 🚀 How to Play

1. Look at the **scrambled word** displayed in the box
2. Type your guess in the **YOUR GUESS** text box
3. Press the **CHECK** button or hit **Enter** on your keyboard
4. If correct:
   - ✅ You earn a point
   - ✅ A new word appears
   - ✅ The word is removed from the list (no repeats)
5. If wrong:
   - ❌ Your failed attempt is recorded
   - ❌ Attempt counter increases
   - ❌ After 10 fails, the word is automatically skipped

## 💻 Technologies Used

| Technology | Purpose |
|------------|---------|
| **C# .NET 8.0** | Programming language |
| **Windows Forms** | GUI framework |
| **.NET WinForms** | Desktop application framework |

## 📁 Project Structure
