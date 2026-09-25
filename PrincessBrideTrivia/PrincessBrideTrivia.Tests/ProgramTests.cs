namespace PrincessBrideTrivia.Tests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void LoadQuestions_ValidFilePath_ReturnsCorrectNumberOfQuestions()
    {
        string filePath = Path.GetRandomFileName();
        try
        {
            // Arrange
            GenerateQuestionsFile(filePath, 2);

            // Act
            Question[] questions = Program.LoadQuestions(filePath);

            // Assert 
            Assert.HasCount(2, questions);
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    [TestMethod]
    [DataRow("1", true)]
    [DataRow("2", false)]
    public void DisplayResult_ValidUserGuess_ReturnsExpectedBoolean(string userGuess, bool expectedResult)
    {
        // Arrange
        Question question = new();
        question.CorrectAnswerIndex = "1";

        // Act
        bool displayResult = Program.DisplayResult(userGuess, question);

        // Assert
        Assert.AreEqual(expectedResult, displayResult);
    }

    [TestMethod]
    public void GetFilePath_WhenCalled_ReturnsExistingFilePath()
    {
        // Arrange

        // Act
        string filePath = Program.GetFilePath();

        // Assert
        Assert.IsTrue(File.Exists(filePath));
    }

    [TestMethod]
    [DataRow(1, 1, "100%")]
    [DataRow(5, 10, "50%")]
    [DataRow(1, 10, "10%")]
    [DataRow(0, 10, "0%")]
    public void GetPercentCorrect_ValidCorrectAndTotalCounts_ReturnsFormattedPercentageString(int numberOfCorrectGuesses,
        int numberOfQuestions, string expectedString)
    {
        // Arrange

        // Act
        string percentage = Program.GetPercentCorrect(numberOfCorrectGuesses, numberOfQuestions);

        // Assert
        Assert.AreEqual(expectedString, percentage);
    }

    [ResourceLock(WellKnownResources.Console)] // MSTEST0074: on 'Console.SetIn'
    [TestMethod]
    public void GetQuizInputFromUser_Input_RejectsInvalidInputsUntilCorrect()
    {
        // Arrange (simulates wrong inputs until a correct one)
        string simInput = "x\n3\n1\n";
        Console.SetIn(new StringReader(simInput));
        
        // Act
        int choice = Program.GetQuizInputFromUser();
        
        // assert
        Assert.AreEqual(1, choice);
    }

    [ResourceLock(WellKnownResources.Console)] // MSTEST0074: on 'Console.SetIn'
    [TestMethod]
    [DataRow("1", 1)]
    [DataRow("2", 2)]
    public void GetQuizInputFromUser_ValidInput_ReturnsCorrectQuizInput(string input, int expected)
    {
        Console.SetIn(new StringReader(input + "\n"));
        
        int choice = Program.GetQuizInputFromUser();
        
        Assert.AreEqual(expected, choice);
    }

    [TestMethod]
    [DataRow(1, "Trivia.txt")]
    [DataRow(2, "Trivia2.txt")]
    public void GetFilePathForChoice_ReturnsCorrectFilePath(int choice, string expectedPath)
    {
        string filePath = Program.GetFilePathForChoice(choice);
        
        Assert.AreEqual(expectedPath, filePath);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(2)]
    public void GetFilePathForChoice_ReturnsExistingFile(int choice)
    {
        string filePath = Program.GetFilePathForChoice(choice);
        
        Assert.IsTrue(File.Exists(filePath));
    }


    #region Testing Helpers

    private static void GenerateQuestionsFile(string filePath, int numberOfQuestions)
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            string[] lines =
            [
                "Question " + i + " this is the question text",
                "Answer 1",
                "Answer 2",
                "Answer 3",
                "2",
            ];
            File.AppendAllLines(filePath, lines);
        }
    }

    #endregion
    
}
