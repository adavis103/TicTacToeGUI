numToScore = {0 : 0, 1 : 1, 2 : 10, 3 : 2000, 4 : 50000}



class Win():
	def __init__(self, p0, p1, p2, p3):
		self.points = []
		self.points.append(p0)
		self.points.append(p1)
		self.points.append(p2)
		self.points.append(p3)

	def filled(self):
		if(self.points[0].val == '0'):
			return '0'
		for p in self.points[1:]:
			if p.val != self.points[0].val:
				return '0'
		return self.points[0].val

	def xStrength(self):
		s = 0
		for p in self.points:
			if p.val == 'X':
				s += 1
		return s

	def oStrength(self):
		s = 0
		for p in self.points:
			if p.val == 'O':
				s += 1
		return s

	def isSplit(self):
		return (self.xStrength() > 0) and (self.oStrength() > 0)

class Point():
	def __init__(self, pos, val):
		self.pos = pos
		self.val = val


class Board():
	def __init__(self):
		self.allPoints = []
		for i in range(64):
			self.allPoints.append(Point(i,'0'))

		self.allWins = []

		# rows
		for i in range(0,64,4):
			self.allWins.append(Win(self.allPoints[i], self.allPoints[i+1], self.allPoints[i+2], self.allPoints[i+3]))

		# columns
		for i in range(0,64,16):
			for j in range(4):
				self.allWins.append(Win(self.allPoints[i+j], self.allPoints[i+j+4], self.allPoints[i+j+8], self.allPoints[i+j+12]))

		#vertical columns
		for i in range(16):
			self.allWins.append(Win(self.allPoints[i], self.allPoints[i+16], self.allPoints[i+32], self.allPoints[i+48]))

		#right x-z diagonals
		for i in range(0,64,16):
			self.allWins.append(Win(self.allPoints[i], self.allPoints[i+5], self.allPoints[i+10], self.allPoints[i+15]))

		#left x-z diagonals
		for i in range(3,64,16):
			self.allWins.append(Win(self.allPoints[i], self.allPoints[i+3], self.allPoints[i+6], self.allPoints[i+9]))
		#upward y-z diagonals
		for i in range(4):
			self.allWins.append(Win(self.allPoints[i], self.allPoints[i+20], self.allPoints[i+40], self.allPoints[i+60]))

		#downward y-z diagonals
		for i in range(12,16):
			self.allWins.append(Win(self.allPoints[i], self.allPoints[i+12], self.allPoints[i+24], self.allPoints[i+36]))

		#right x-y diagonals
		for i in range(0,16,4):
			self.allWins.append(Win(self.allPoints[i], self.allPoints[i+17], self.allPoints[i+34], self.allPoints[i+51]))

		#left x-y diagonals
		for i in range(3,17,4):
			self.allWins.append(Win(self.allPoints[i], self.allPoints[i+15], self.allPoints[i+30], self.allPoints[i+45]))

		# 2-D diagonals
		self.allWins.append(Win(self.allPoints[0], self.allPoints[21], self.allPoints[42], self.allPoints[63]))
		self.allWins.append(Win(self.allPoints[3], self.allPoints[22], self.allPoints[41], self.allPoints[60]))
		self.allWins.append(Win(self.allPoints[12], self.allPoints[25], self.allPoints[38], self.allPoints[51]))
		self.allWins.append(Win(self.allPoints[15], self.allPoints[26], self.allPoints[37], self.allPoints[48]))

	def move(self, mover, pos):
		self.allPoints[pos].val = mover

	def isMovesLeft(self):
		for p in self.allPoints:
			if p.val == '0': return True
		return False

	def gameOver(self):
		for win in self.allWins:
			w = win.filled()
			if w != '0':
				return w
		return '0'

	def utilityFunction(self):
		score = 0
		for win in self.allWins:
			if win.isSplit() == False:
				sX = win.xStrength()
				score += numToScore[sX]
				sO = win.oStrength()
				if sO == 4:
					score -= 2*numToScore[sO]
				else:
					score -= numToScore[sO]
		return score


	def minimax(self, isMax, currentDepth, maxDepth, mover):
		score = self.utilityFunction()

		if (self.gameOver() != '0') or (currentDepth == maxDepth) or (self.isMovesLeft() == False):
			return score


		if isMax:
			best = - 1000000
			for p in self.allPoints:
				if p.val == '0':
					p.val = mover
					best = max(best, self.minimax(not isMax, currentDepth + 1, maxDepth, mover))
					p.val = '0'
			return best

		else:
			if mover == 'X': opponent = '0'
			else: opponent = 'X'

			best = 1000000
			for p in self.allPoints:
				if p.val == '0':
					p.val = opponent
					best = min(best, self.minimax(not isMax, currentDepth + 1, maxDepth, mover))
					p.val = '0'
			return best

	def findBestMove(self,mover, depth):
		bestMove = -1
		if mover == 'X':
			bestScore = - 1000000
			for i, p in enumerate(self.allPoints):
				if p.val == '0':
					p.val = mover
					val = self.minimax(True, 1, depth, mover)
					p.val = '0'
					if val > bestScore:
						bestMove = i
						bestScore = val

		else:
			bestScore = 1000000
			for i, p in enumerate(self.allPoints):
				if p.val == '0':
					p.val = mover
					val = self.minimax(False, 1, depth, mover)
					p.val = '0'
					if val < bestScore:
						bestMove = i
						bestScore = val

		return bestMove






if __name__ == "__main__":
    b = Board()
    player = 'X'
    ai = 'O'
    depth = 3
    b.move(player,10)
    b.move(ai, 28)
    b.move(player, 0)
    print(b.findBestMove(ai,3))

