using System;

public class DrawCommand : ICommand {
    private LineData lineData;
    public DrawCommand(LineData lineData) {
        this.lineData = lineData;
    }

    public LineData Undo() {
        return lineData;
    }
}