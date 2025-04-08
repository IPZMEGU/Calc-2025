import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.util.HashMap;
import java.util.Map;

public class CalculatorFormKorotchukBohdan extends JFrame {

    private JTextField displayField;
    private JTextField memoryField;
    private double memoryValue = 0;
    private String operation = "";
    private double resultValue = 0;
    private boolean startNewNumber = true;
    private boolean isDarkTheme = false;

    private JPanel buttonPanel;
    private JButton themeButton;
    private final Map<String, Runnable> commandActions = new HashMap<>();

    public CalculatorFormKorotchukBohdan() {
        setTitle("Calculator - Developer: Korchuk Bohdan Ivanovych");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setSize(400, 550);
        setLocationRelativeTo(null);
        setLayout(new BorderLayout());

        memoryField = new JTextField("Memory: 0");
        memoryField.setEnabled(false);
        memoryField.setHorizontalAlignment(JTextField.RIGHT);
        memoryField.setFont(new Font("Arial", Font.PLAIN, 14));
        add(memoryField, BorderLayout.NORTH);

        displayField = new JTextField("0");
        displayField.setHorizontalAlignment(JTextField.RIGHT);
        displayField.setEditable(false);
        displayField.setFont(new Font("Arial", Font.BOLD, 28));
        add(displayField, BorderLayout.CENTER);

        buttonPanel = new JPanel();
        buttonPanel.setLayout(new GridLayout(6, 5, 5, 5));

        String[] buttons = {
            "OFF", "Back", "C", "sqrt", "MR",
            "MC", "M+", "M-", "7", "8",
            "9", "/", "4", "5", "6",
            "*", "1", "2", "3", "-",
            "0", "+/-", ".", "+", "=",
            "1/x", "x^2", "x^3", "Change Theme"
        };

        for (String text : buttons) {
            JButton button = new JButton(text);
            button.setFont(new Font("Arial", Font.PLAIN, 18));
            button.addActionListener(new ButtonClickListener());
            if ("Change Theme".equals(text)) {
                themeButton = button;
                themeButton.setActionCommand("Change Theme");
            }
            buttonPanel.add(button);
        }
        add(buttonPanel, BorderLayout.SOUTH);

        initializeCommandActions();
    }

    private void initializeCommandActions() {
        commandActions.put("C", this::clear);
        commandActions.put("Back", this::backspace);
        commandActions.put("+/-", this::toggleSign);
        commandActions.put("sqrt", this::calculateSquareRoot);
        commandActions.put("1/x", this::calculateReciprocal);
        commandActions.put("OFF", () -> System.exit(0));
        commandActions.put("MR", this::recallMemory);
        commandActions.put("MC", this::clearMemory);
        commandActions.put("M+", this::addToMemory);
        commandActions.put("M-", this::subtractFromMemory);
        commandActions.put("=", this::calculateResult);
        commandActions.put("x^2", this::square);
        commandActions.put("x^3", this::cube);
        commandActions.put("Change Theme", this::changeTheme);
    }

    private class ButtonClickListener implements ActionListener {
        public void actionPerformed(ActionEvent e) {
            String command = e.getActionCommand();
            if (command.matches("[0-9]")) {
                handleNumberInput(command);
            } else if (command.equals(".")) {
                handleDecimalInput();
            } else if (commandActions.containsKey(command)) {
                commandActions.get(command).run();
            } else {
                handleOperation(command);
            }
        }
    }

    private void handleNumberInput(String number) {
        if (startNewNumber) {
            displayField.setText(number);
            startNewNumber = false;
        } else {
            displayField.setText(displayField.getText() + number);
        }
    }

    private void handleDecimalInput() {
        if (!displayField.getText().contains(".")) {
            displayField.setText(displayField.getText() + ".");
        }
    }

    private void clear() {
        displayField.setText("0");
        operation = "";
        resultValue = 0;
        startNewNumber = true;
    }

    private void backspace() {
        String text = displayField.getText();
        if (text.length() > 1) {
            displayField.setText(text.substring(0, text.length() - 1));
        } else {
            displayField.setText("0");
        }
    }

    private void toggleSign() {
        double val = Double.parseDouble(displayField.getText());
        displayField.setText(Double.toString(-val));
    }

    private void calculateSquareRoot() {
        double val = Double.parseDouble(displayField.getText());
        displayField.setText(Double.toString(Math.sqrt(val)));
    }

    private void calculateReciprocal() {
        double val = Double.parseDouble(displayField.getText());
        displayField.setText(Double.toString(1 / val));
    }

    private void recallMemory() {
        displayField.setText(Double.toString(memoryValue));
    }

    private void clearMemory() {
        memoryValue = 0;
        memoryField.setText("Memory: " + memoryValue);
    }

    private void addToMemory() {
        memoryValue += Double.parseDouble(displayField.getText());
        memoryField.setText("Memory: " + memoryValue);
    }

    private void subtractFromMemory() {
        memoryValue -= Double.parseDouble(displayField.getText());
        memoryField.setText("Memory: " + memoryValue);
    }

    private void calculateResult() {
        calculate(Double.parseDouble(displayField.getText()));
        operation = "";
        startNewNumber = true;
    }

    private void handleOperation(String op) {
        if (!operation.isEmpty()) {
            calculate(Double.parseDouble(displayField.getText()));
        } else {
            resultValue = Double.parseDouble(displayField.getText());
        }
        operation = op;
        startNewNumber = true;
    }

    private void calculate(double number) {
        switch (operation) {
            case "+":
                resultValue += number;
                break;
            case "-":
                resultValue -= number;
                break;
            case "*":
                resultValue *= number;
                break;
            case "/":
                resultValue /= number;
                break;
        }
        displayField.setText(Double.toString(resultValue));
    }

    private void square() {
        double val = Double.parseDouble(displayField.getText());
        displayField.setText(Double.toString(val * val));
        startNewNumber = true;
    }

    private void cube() {
        double val = Double.parseDouble(displayField.getText());
        displayField.setText(Double.toString(val * val * val));
        startNewNumber = true;
    }

    private void changeTheme() {
        if (!isDarkTheme) {
            setDarkTheme();
            isDarkTheme = true;
            updateThemeButton("☀");
        } else {
            setLightTheme();
            isDarkTheme = false;
            updateThemeButton("☾");
        }
    }

    private void setDarkTheme() {
        getContentPane().setBackground(Color.DARK_GRAY);
        displayField.setBackground(Color.GRAY);
        displayField.setForeground(Color.WHITE);
        memoryField.setBackground(Color.GRAY);
        memoryField.setForeground(Color.WHITE);
        updateAllButtons(Color.WHITE, Color.DARK_GRAY);
    }

    private void setLightTheme() {
        getContentPane().setBackground(Color.WHITE);
        displayField.setBackground(Color.WHITE);
        displayField.setForeground(Color.BLACK);
        memoryField.setBackground(Color.WHITE);
        memoryField.setForeground(Color.BLACK);
        updateAllButtons(Color.BLACK, Color.LIGHT_GRAY);
    }

    private void updateAllButtons(Color textColor, Color bgColor) {
        for (Component comp : buttonPanel.getComponents()) {
            if (comp instanceof JButton) {
                JButton btn = (JButton) comp;
                if ("Change Theme".equals(btn.getActionCommand())) {
                    continue;
                }
                btn.setForeground(textColor);
                btn.setBackground(bgColor);
            }
        }
        if (themeButton != null) {
            themeButton.setForeground(textColor);
            themeButton.setBackground(bgColor);
        }
    }

    private void updateThemeButton(String icon) {
        if (themeButton != null) {
            themeButton.setText(icon);
        }
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            CalculatorFormKorotchukBohdan calc = new CalculatorFormKorotchukBohdan();
            calc.setVisible(true);
        });
    }
}
