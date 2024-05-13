public class EraseCommand : ICommand {
    private LineData lineData;

    public EraseCommand(LineData lineData) {
        this.lineData = lineData;
    }

    public LineData Undo() {
        return lineData;
    }
}