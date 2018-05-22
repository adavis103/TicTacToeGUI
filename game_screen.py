import sys
from PyQt5.QtWidgets import QApplication, QWidget, QToolTip, QPushButton, QMessageBox
from PyQt5.QtGui import  QFont, QPen, QColor
from PyQt5 import QtGui, QtCore
from board import Win, Point, Board
from instructions import *
from ScoreScreen import ScoreScreen

emptyStyleSheet = """
    color : white;
    background-color : #384749;
        """
xStyleSheet = """
    color : white;
    background-color : #BC463E;
        """

oStyleSheet = """
    color : black;
    background-color : #EEF5DB;
        """


class gameScreen(QWidget):
    def __init__(self):
        super().__init__()
        self.boardButtons = []
        self.board = Board()
        self.playerChar = 'X'
        self.playerInitials = ''
        # self.scoreScreen = None
        self.aiChar = 'O'
        self.playerMove = -1
        #TODO: May be unused, maybe delete.
        self.movesMade = set()
        self.pen = QtGui.QPen(QtGui.QColor(0,0,0))
        self.pen.setWidth(3)
        self.brush = QtGui.QBrush(QtGui.QColor(122, 158, 159, 128))
        self.initUI()
        self.planePolygon1 = self.makeFirstPlanePoly()
        self.planePolygon2 = self.makeSecondPlanePoly()
        self.planePolygon3 = self.makeThirdPlanePoly()
        self.planePolygon4 = self.makeFourthPlanePoly()
        self.linesOnBoards = self.makeLines()


    def setPlayerInitials(self, newInitials):
        self.playerInitials = newInitials

    def setScoreScreen(self, newScoreScreen):
        pass
        self.scoreScreen = newScoreScreen

    #check button pressed and send to AI, then move AI
    def buttonClicked(self, num):
        move = self.makeMove(self.playerChar, num)
        if move == -1:
            return
        print("players move: {0}".format(move))
        self.board.move(self.playerChar, move)
        if self.board.gameOver() == self.playerChar:
            ScoreScreen.updateScores(self.playerInitials)
            print("Player won")
            reply = QMessageBox.question(self, 'You Won', 'You Won! Do you want to play again', QMessageBox.Yes | QMessageBox.No, QMessageBox.Yes)
            if reply == QMessageBox.Yes:
                self.close()
                tmp = self.playerInitials
                self = gameScreen()
                self.setPlayerInitials(tmp)
            else:
                self.close()

        aiMove = self.board.findBestMove(self.aiChar, 2)
        self.makeMove(self.aiChar, aiMove)
        self.board.move(self.aiChar, aiMove)
        print("AI's move: {0}".format(aiMove))
        if self.board.gameOver() == self.aiChar:
            print("AI won")
            reply = QMessageBox.question(self, 'You Lost', 'You Lost! Do you want to play again', QMessageBox.Yes | QMessageBox.No, QMessageBox.Yes)
            if reply == QMessageBox.Yes:
                self.close()
                tmp = self.playerInitials
                self = gameScreen()
                self.setPlayerInitials(tmp)
            else:
                self.close()

    #make move on GUI board
    def makeMove(self, moveChar, num):
        if self.boardButtons[num].text() == 'X' or self.boardButtons[num].text() == 'O':
            return -1
        self.boardButtons[num].setText(moveChar)
        if moveChar == 'X':
            self.boardButtons[num].setStyleSheet(xStyleSheet)
        if moveChar == 'O':
                self.boardButtons[num].setStyleSheet(oStyleSheet)
        return num

    def setPlayerToX(self):
        self.playerChar = 'X'
        self.aiChar = 'O'

    def setPlayerToO(self):
        self.playerChar = 'O'
        self.aiChar = 'X'

    def getPlayerMove(self):
        return self.playerMove

    def makeDefaultButton(self):
        button = QPushButton('', self)
        button.resize(100, 25)
        button.setStyleSheet(emptyStyleSheet)
        return button

    #Set up each of the four planes of buttons
    def setUpFirstPlaneBoardButtons(self):
        buttons = [self.makeDefaultButton() for _ in range(0,16)]
        buttons[0].move(50, 60)
        buttons[0].clicked.connect(lambda: self.buttonClicked(0) )
        buttons[1].move(200, 60)
        buttons[1].clicked.connect(lambda: self.buttonClicked(1) )
        buttons[2].move(350, 60)
        buttons[2].clicked.connect(lambda: self.buttonClicked(2) )
        buttons[3].move(500, 60)
        buttons[3].clicked.connect(lambda: self.buttonClicked(3) )
        buttons[4].move(75, 95)
        buttons[4].clicked.connect(lambda: self.buttonClicked(4) )
        buttons[5].move(225, 95)
        buttons[5].clicked.connect(lambda: self.buttonClicked(5) )
        buttons[6].move(375, 95)
        buttons[6].clicked.connect(lambda: self.buttonClicked(6) )
        buttons[7].move(525, 95)
        buttons[7].clicked.connect(lambda: self.buttonClicked(7) )
        buttons[8].move(90, 130)
        buttons[8].clicked.connect(lambda: self.buttonClicked(8) )
        buttons[9].move(240, 130)
        buttons[9].clicked.connect(lambda: self.buttonClicked(9) )
        buttons[10].move(390, 130)
        buttons[10].clicked.connect(lambda: self.buttonClicked(10) )
        buttons[11].move(540, 130)
        buttons[11].clicked.connect(lambda: self.buttonClicked(11) )
        buttons[12].move(115, 165)
        buttons[12].clicked.connect(lambda: self.buttonClicked(12) )
        buttons[13].move(265, 165)
        buttons[13].clicked.connect(lambda: self.buttonClicked(13) )
        buttons[14].move(415, 165)
        buttons[14].clicked.connect(lambda: self.buttonClicked(14) )
        buttons[15].move(565, 165)
        buttons[15].clicked.connect(lambda: self.buttonClicked(15) )
        return buttons

    def setUpSecondPlaneBoardButtons(self):
        buttons = [self.makeDefaultButton() for _ in range(0,16)]
        buttons[0].move(50, 60+150)
        buttons[0].clicked.connect(lambda: self.buttonClicked(16) )
        buttons[1].move(200, 60+150)
        buttons[1].clicked.connect(lambda: self.buttonClicked(17) )
        buttons[2].move(350, 60+150)
        buttons[2].clicked.connect(lambda: self.buttonClicked(18) )
        buttons[3].move(500, 60+150)
        buttons[3].clicked.connect(lambda: self.buttonClicked(19) )
        buttons[4].move(75, 95+150)
        buttons[4].clicked.connect(lambda: self.buttonClicked(20) )
        buttons[5].move(225, 95+150)
        buttons[5].clicked.connect(lambda: self.buttonClicked(21) )
        buttons[6].move(375, 95+150)
        buttons[6].clicked.connect(lambda: self.buttonClicked(22) )
        buttons[7].move(525, 95+150)
        buttons[7].clicked.connect(lambda: self.buttonClicked(23) )
        buttons[8].move(90, 130+150)
        buttons[8].clicked.connect(lambda: self.buttonClicked(24) )
        buttons[9].move(240, 130+150)
        buttons[9].clicked.connect(lambda: self.buttonClicked(25) )
        buttons[10].move(390, 130+150)
        buttons[10].clicked.connect(lambda: self.buttonClicked(26) )
        buttons[11].move(540, 130+150)
        buttons[11].clicked.connect(lambda: self.buttonClicked(27) )
        buttons[12].move(115, 165+150)
        buttons[12].clicked.connect(lambda: self.buttonClicked(28) )
        buttons[13].move(265, 165+150)
        buttons[13].clicked.connect(lambda: self.buttonClicked(29) )
        buttons[14].move(415, 165+150)
        buttons[14].clicked.connect(lambda: self.buttonClicked(30) )
        buttons[15].move(565, 165+150)
        buttons[15].clicked.connect(lambda: self.buttonClicked(31) )
        return  buttons

    def setUpThirdPlaneBoardButtons(self):
        buttons = [self.makeDefaultButton() for _ in range(0,16)]
        buttons[0].move(50, 60+300)
        buttons[0].clicked.connect(lambda: self.buttonClicked(32) )
        buttons[1].move(200, 60+300)
        buttons[1].clicked.connect(lambda: self.buttonClicked(33) )
        buttons[2].move(350, 60+300)
        buttons[2].clicked.connect(lambda: self.buttonClicked(34) )
        buttons[3].move(500, 60+300)
        buttons[3].clicked.connect(lambda: self.buttonClicked(35) )
        buttons[4].move(75, 95+300)
        buttons[4].clicked.connect(lambda: self.buttonClicked(36) )
        buttons[5].move(225, 95+300)
        buttons[5].clicked.connect(lambda: self.buttonClicked(37) )
        buttons[6].move(375, 95+300)
        buttons[6].clicked.connect(lambda: self.buttonClicked(38) )
        buttons[7].move(525, 95+300)
        buttons[7].clicked.connect(lambda: self.buttonClicked(39) )
        buttons[8].move(90, 130+300)
        buttons[8].clicked.connect(lambda: self.buttonClicked(40) )
        buttons[9].move(240, 130+300)
        buttons[9].clicked.connect(lambda: self.buttonClicked(41) )
        buttons[10].move(390, 130+300)
        buttons[10].clicked.connect(lambda: self.buttonClicked(42) )
        buttons[11].move(540, 130+300)
        buttons[11].clicked.connect(lambda: self.buttonClicked(43) )
        buttons[12].move(115, 165+300)
        buttons[12].clicked.connect(lambda: self.buttonClicked(44) )
        buttons[13].move(265, 165+300)
        buttons[13].clicked.connect(lambda: self.buttonClicked(45) )
        buttons[14].move(415, 165+300)
        buttons[14].clicked.connect(lambda: self.buttonClicked(46) )
        buttons[15].move(565, 165+300)
        buttons[15].clicked.connect(lambda: self.buttonClicked(47) )
        return  buttons

    def setUpFourthPlaneBoardButtons(self):
        buttons = [self.makeDefaultButton() for _ in range(0,16)]
        buttons[0].move(50, 60+450)
        buttons[0].clicked.connect(lambda: self.buttonClicked(48) )
        buttons[1].move(200, 60+450)
        buttons[1].clicked.connect(lambda: self.buttonClicked(49) )
        buttons[2].move(350, 60+450)
        buttons[2].clicked.connect(lambda: self.buttonClicked(50) )
        buttons[3].move(500, 60+450)
        buttons[3].clicked.connect(lambda: self.buttonClicked(51) )
        buttons[4].move(75, 95+450)
        buttons[4].clicked.connect(lambda: self.buttonClicked(52) )
        buttons[5].move(225, 95+450)
        buttons[5].clicked.connect(lambda: self.buttonClicked(53) )
        buttons[6].move(375, 95+450)
        buttons[6].clicked.connect(lambda: self.buttonClicked(54) )
        buttons[7].move(525, 95+450)
        buttons[7].clicked.connect(lambda: self.buttonClicked(55) )
        buttons[8].move(90, 130+450)
        buttons[8].clicked.connect(lambda: self.buttonClicked(56) )
        buttons[9].move(240, 130+450)
        buttons[9].clicked.connect(lambda: self.buttonClicked(57) )
        buttons[10].move(390, 130+450)
        buttons[10].clicked.connect(lambda: self.buttonClicked(58) )
        buttons[11].move(540, 130+450)
        buttons[11].clicked.connect(lambda: self.buttonClicked(59) )
        buttons[12].move(115, 165+450)
        buttons[12].clicked.connect(lambda: self.buttonClicked(60) )
        buttons[13].move(265, 165+450)
        buttons[13].clicked.connect(lambda: self.buttonClicked(61) )
        buttons[14].move(415, 165+450)
        buttons[14].clicked.connect(lambda: self.buttonClicked(62) )
        buttons[15].move(565, 165+450)
        buttons[15].clicked.connect(lambda: self.buttonClicked(63) )
        return  buttons

    def quitButtonClicked(self):
        reply = QMessageBox.question(self, 'Quit', 'Are you sure you want to quit', QMessageBox.Yes | QMessageBox.No, QMessageBox.Yes)
        if reply == QMessageBox.Yes:
            self.close()

    #set all buttons on board
    def setUpBoardButtons(self):
        QToolTip.setFont(QFont('SansSerif', 10))
        quitButton = QPushButton('Close Window', self)
        quitButton.clicked.connect(self.quitButtonClicked)
        quitButton.setToolTip("Quit the game to the main menu")
        quitButton.resize(quitButton.sizeHint())
        quitButton.move(550, 20)
        # rulesButton = QPushButton('Rules!', self)
        # rulesButton.resize(rulesButton.sizeHint())
        # rulesButton.setToolTip('Show the game rules screen')
        # rulesButton.move(325, 700)
        self.boardButtons = self.boardButtons + self.setUpFirstPlaneBoardButtons()
        self.boardButtons = self.boardButtons + self.setUpSecondPlaneBoardButtons()
        self.boardButtons = self.boardButtons + self.setUpThirdPlaneBoardButtons()
        self.boardButtons = self.boardButtons + self.setUpFourthPlaneBoardButtons()


    #600 width, 800 height
    #Set up each of the polygon planes (lines on board)
    def makeFirstPlanePoly(self):
        polygon = QtGui.QPolygonF()
        polygon.append(QtCore.QPointF(600, 60+(0*150)))
        polygon.append(QtCore.QPointF(30, 60+(0*150)))
        polygon.append(QtCore.QPointF(90, 200+(0*150)))
        polygon.append(QtCore.QPointF(685, 200+(0*150)))
        return polygon

    def makeSecondPlanePoly(self):
        polygon = QtGui.QPolygonF()
        polygon.append(QtCore.QPointF(600, 60+(1*150)))
        polygon.append(QtCore.QPointF(30, 60+(1*150)))
        polygon.append(QtCore.QPointF(90, 200+(1*150)))
        polygon.append(QtCore.QPointF(685, 200+(1*150)))
        return polygon

    def makeThirdPlanePoly(self):
        polygon = QtGui.QPolygonF()
        polygon.append(QtCore.QPointF(600, 60+(2*150)))
        polygon.append(QtCore.QPointF(30, 60+(2*150)))
        polygon.append(QtCore.QPointF(90, 200+(2*150)))
        polygon.append(QtCore.QPointF(685, 200+(2*150)))
        return polygon

    def makeFourthPlanePoly(self):
        polygon = QtGui.QPolygonF()
        polygon.append(QtCore.QPointF(600, 60+(3*150)))
        polygon.append(QtCore.QPointF(30, 60+(3*150)))
        polygon.append(QtCore.QPointF(90, 200+(3*150)))
        polygon.append(QtCore.QPointF(685, 200+(3*150)))
        return polygon

    #Returns a list of lines on the boards
    def makeLines(self):
        lines = []
        lines = lines + self.makeLinesFirstBoard()
        lines = lines + self.makeLinesSecondBoard()
        lines = lines + self.makeLinesThirdBoard()
        lines = lines + self.makeLinesFourthBoard()
        return lines

    #draw lines on board window
    def makeLinesFirstBoard(self):
        lines = []
        #Lines vertically
        polygon1 = QtGui.QPolygonF()
        polygon1.append(QtCore.QPointF(30 + 140, 60))
        polygon1.append(QtCore.QPointF(90 + 144, 200))
        lines.append(polygon1)

        polygon2 = QtGui.QPolygonF()
        polygon2.append(QtCore.QPointF(30 + 142*2, 60))
        polygon2.append(QtCore.QPointF(90 + 146*2, 200))
        lines.append(polygon2)

        polygon3 = QtGui.QPolygonF()
        polygon3.append(QtCore.QPointF(30 + 144 * 3, 60))
        polygon3.append(QtCore.QPointF(90 + 149 * 3, 200))
        lines.append(polygon3)

        #Lines Horizontally
        polygon4 = QtGui.QPolygonF()
        polygon4.append(QtCore.QPointF(42, 90))
        polygon4.append(QtCore.QPointF(620, 90))
        lines.append(polygon4)

        polygon5 = QtGui.QPolygonF()
        polygon5.append(QtCore.QPointF(56, 125))
        polygon5.append(QtCore.QPointF(638, 125))
        lines.append(polygon5)

        polygon6 = QtGui.QPolygonF()
        polygon6.append(QtCore.QPointF(72, 160))
        polygon6.append(QtCore.QPointF(660, 160))
        lines.append(polygon6)

        return lines

    def makeLinesSecondBoard(self):
        lines = []
        #Lines vertically
        polygon1 = QtGui.QPolygonF()
        polygon1.append(QtCore.QPointF(30 + 140, 60+150))
        polygon1.append(QtCore.QPointF(90 + 144, 200+150))
        lines.append(polygon1)

        polygon2 = QtGui.QPolygonF()
        polygon2.append(QtCore.QPointF(30 + 142*2, 60+150))
        polygon2.append(QtCore.QPointF(90 + 146*2, 200+150))
        lines.append(polygon2)

        polygon3 = QtGui.QPolygonF()
        polygon3.append(QtCore.QPointF(30 + 144 * 3, 60+150))
        polygon3.append(QtCore.QPointF(90 + 149 * 3, 200+150))
        lines.append(polygon3)

        #Lines Horizontally
        polygon4 = QtGui.QPolygonF()
        polygon4.append(QtCore.QPointF(42, 90+150))
        polygon4.append(QtCore.QPointF(620, 90+150))
        lines.append(polygon4)

        polygon5 = QtGui.QPolygonF()
        polygon5.append(QtCore.QPointF(56, 125+150))
        polygon5.append(QtCore.QPointF(638, 125+150))
        lines.append(polygon5)

        polygon6 = QtGui.QPolygonF()
        polygon6.append(QtCore.QPointF(72, 160+150))
        polygon6.append(QtCore.QPointF(660, 160+150))
        lines.append(polygon6)

        return lines


    def makeLinesThirdBoard(self):
        lines = []
        #Lines vertically
        polygon1 = QtGui.QPolygonF()
        polygon1.append(QtCore.QPointF(30 + 140, 60+300))
        polygon1.append(QtCore.QPointF(90 + 144, 200+300))
        lines.append(polygon1)

        polygon2 = QtGui.QPolygonF()
        polygon2.append(QtCore.QPointF(30 + 142*2, 60+300))
        polygon2.append(QtCore.QPointF(90 + 146*2, 200+300))
        lines.append(polygon2)

        polygon3 = QtGui.QPolygonF()
        polygon3.append(QtCore.QPointF(30 + 144 * 3, 60+300))
        polygon3.append(QtCore.QPointF(90 + 149 * 3, 200+300))
        lines.append(polygon3)

        #Lines Horizontally
        polygon4 = QtGui.QPolygonF()
        polygon4.append(QtCore.QPointF(42, 90+300))
        polygon4.append(QtCore.QPointF(620, 90+300))
        lines.append(polygon4)

        polygon5 = QtGui.QPolygonF()
        polygon5.append(QtCore.QPointF(56, 125+300))
        polygon5.append(QtCore.QPointF(638, 125+300))
        lines.append(polygon5)

        polygon6 = QtGui.QPolygonF()
        polygon6.append(QtCore.QPointF(72, 160+300))
        polygon6.append(QtCore.QPointF(660, 160+300))
        lines.append(polygon6)

        return lines


    def makeLinesFourthBoard(self):
        lines = []
        #Lines vertically
        polygon1 = QtGui.QPolygonF()
        polygon1.append(QtCore.QPointF(30 + 140, 60+450))
        polygon1.append(QtCore.QPointF(90 + 144, 200+450))
        lines.append(polygon1)

        polygon2 = QtGui.QPolygonF()
        polygon2.append(QtCore.QPointF(30 + 142*2, 60+450))
        polygon2.append(QtCore.QPointF(90 + 146*2, 200+450))
        lines.append(polygon2)

        polygon3 = QtGui.QPolygonF()
        polygon3.append(QtCore.QPointF(30 + 144 * 3, 60+450))
        polygon3.append(QtCore.QPointF(90 + 149 * 3, 200+450))
        lines.append(polygon3)

        #Lines Horizontally
        polygon4 = QtGui.QPolygonF()
        polygon4.append(QtCore.QPointF(42, 90+450))
        polygon4.append(QtCore.QPointF(620, 90+450))
        lines.append(polygon4)

        polygon5 = QtGui.QPolygonF()
        polygon5.append(QtCore.QPointF(56, 125+450))
        polygon5.append(QtCore.QPointF(638, 125+450))
        lines.append(polygon5)

        polygon6 = QtGui.QPolygonF()
        polygon6.append(QtCore.QPointF(72, 160+450))
        polygon6.append(QtCore.QPointF(660, 160+450))
        lines.append(polygon6)

        return lines


    def initUI(self):
        self.setUpBoardButtons()

        self.setFixedSize(700, 750)
        self.setWindowTitle("Main Game Screen")
        palette = self.palette()
        palette.setColor(self.backgroundRole(), QtGui.QColor(184, 216, 216))
        self.setPalette(palette)
        self.show()

    def closeEvent(self, event):
        pass 

    def setBoard(self, newBoard):
        self.board = newBoard

    def getBoard(self):
        return self.board

    def paintEvent(self, event):
        painter = QtGui.QPainter(self)
        painter.setPen(self.pen)
        painter.setBrush(self.brush)
        painter.drawPolygon(self.planePolygon1)
        painter.drawPolygon(self.planePolygon2)
        painter.drawPolygon(self.planePolygon3)
        painter.drawPolygon(self.planePolygon4)
        for line in self.linesOnBoards:
            painter.drawPolygon(line)


if __name__ == '__main__':
    app = QApplication(sys.argv)
    screen = gameScreen()
    screen.makeMove('O', 20)
    sys.exit(app.exec_())