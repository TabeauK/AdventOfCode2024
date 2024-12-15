using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security;

namespace Solutions
{
    public class Warehouse : IMyParsable<Warehouse>
    {
        readonly List<(int X, int Y)> directions = new()
        {
            new(0, -1), // UP
            new(1, 0),  // RIGHT
            new(0, 1),  // DOWN
            new(-1,0),  // LEFT
        };

        List<int> robotMoves = new();

        // Part 1
        HashSet<(int X, int Y)> walls = new();
        HashSet<(int X, int Y)> startBoxes = new();
        (int X, int Y) startRobot;

        // Part 2
        HashSet<(int X, int Y)> secondWalls = new();
        List<((int X, int Y), (int X, int Y))> secondStartBoxes = new();
        (int X, int Y) secondStartRobot;

        static Warehouse IMyParsable<Warehouse>.Parse(string s)
        {
            throw new NotImplementedException();
        }

        static Warehouse IMyParsable<Warehouse>.ParseMultiline(ICollection<string> s)
        {
            HashSet<(int X, int Y)> walls = new();
            HashSet<(int X, int Y)> startBoxes = new();
            List<int> robotMoves = new();
            (int X, int Y) startRobot = (0, 0);
            HashSet<(int X, int Y)> secondWalls = new();
            List<((int X, int Y), (int X, int Y))> secondStartBoxes = new();
            (int X, int Y) secondStartRobot = (0, 0);

            List<string> input = s.ToList();
            bool part1 = true;
            for (int i = 0; i < s.Count; i++)
            {
                if (string.IsNullOrEmpty(input[i]))
                {
                    part1 = false;
                    continue;
                }

                if (part1)
                {
                    for (int j = 0; j < input[i].Length; j++)
                        switch (input[i][j])
                        {
                            case '#':
                                walls.Add((j, i));
                                secondWalls.Add((2 * j, i));
                                secondWalls.Add((2 * j + 1, i));
                                break;
                            case '@':
                                startRobot = (j, i);
                                secondStartRobot = (2 * j, i);
                                break;
                            case 'O':
                                startBoxes.Add((j, i));
                                secondStartBoxes.Add(((2 * j, i), (2 * j + 1, i)));
                                break;
                            default:
                                break;
                        }
                    continue;
                }

                foreach (char d in input[i])
                    switch (d)
                    {
                        case '^':
                            robotMoves.Add(0);
                            break;
                        case '>':
                            robotMoves.Add(1);
                            break;
                        case 'v':
                            robotMoves.Add(2);
                            break;
                        case '<':
                            robotMoves.Add(3);
                            break;
                    }
            }
            return new()
            {
                walls = walls,
                startRobot = startRobot,
                startBoxes = startBoxes,
                secondWalls = secondWalls,
                secondStartRobot = secondStartRobot,
                secondStartBoxes = secondStartBoxes,
                robotMoves = robotMoves,
            };
        }

        // Part 1
        public int MoveRobot()
        {
            HashSet<(int X, int Y)> boxes = new(startBoxes);

            (int X, int Y) robotPosition = startRobot;
            foreach (int d in robotMoves)
                if (TryMoveObject(d, robotPosition, ref boxes))
                    robotPosition = (robotPosition.X + directions[d].X, robotPosition.Y + directions[d].Y);

            return boxes.Sum(x => x.X + x.Y * 100);
        }

        bool TryMoveObject(int direction, (int X, int Y) ob, ref HashSet<(int X, int Y)> boxes)
        {
            (int X, int Y) nextOb = (ob.X + directions[direction].X, ob.Y + directions[direction].Y);
            if (walls.Contains(nextOb))
                return false;

            bool needsUpdate = true;
            if (boxes.Contains(nextOb))
                needsUpdate = TryMoveObject(direction, nextOb, ref boxes);

            if (needsUpdate && boxes.Contains(ob))
            {
                boxes.Remove(ob);
                boxes.Add(nextOb);
            }
            return needsUpdate;
        }

        // Part 2
        List<((int X, int Y), (int X, int Y))> CanMoveBigBox(int direction, (int X, int Y) ob, ref List<((int X, int Y), (int X, int Y))> boxes, out bool canRobotMove)
        {
            Stack<(int X, int Y)> stack = new();
            HashSet<((int X, int Y), (int X, int Y))> queued = new();
            stack.Push(ob);
            canRobotMove = true;
            while (stack.Count > 0)
            {
                (int X, int Y) = stack.Pop();
                (int X, int Y) nextOb = (X + directions[direction].X, Y + directions[direction].Y);

                // Check for wall
                if (secondWalls.Contains(nextOb))
                {
                    canRobotMove = false;
                    return new();
                }

                // Check for another box
                ((int X, int Y), (int X, int Y)) box;
                if (boxes.Any(x => x.Item1 == nextOb))
                {
                    box = boxes.Find(x => x.Item1 == nextOb);
                    queued.Add(box);
                }
                else if (boxes.Any(x => x.Item2 == nextOb))
                {
                    box = boxes.Find(x => x.Item2 == nextOb);
                    queued.Add(box);
                }
                else
                    continue;

                // Add next box to queue depending on its relative position
                if (box.Item1.X + directions[direction].X == box.Item2.X && box.Item1.Y + directions[direction].Y == box.Item2.Y)
                    stack.Push(box.Item2);
                else if (box.Item2.X + directions[direction].X == box.Item1.X && box.Item2.Y + directions[direction].Y == box.Item1.Y)
                    stack.Push(box.Item1);
                else
                {
                    stack.Push(box.Item1);
                    stack.Push(box.Item2);
                }
            }
            return queued.ToList();
        }

        public int MoveSecondRobot()
        {
            List<((int X, int Y), (int X, int Y))> boxes = new(secondStartBoxes);
            (int X, int Y) robotPosition = secondStartRobot;
            foreach (int d in robotMoves)
            {
                var boxesToMove = CanMoveBigBox(d, robotPosition, ref boxes, out bool canRobotMove);
                foreach (var b in boxesToMove)
                {
                    boxes.Add(((b.Item1.X + directions[d].X, b.Item1.Y + directions[d].Y), (b.Item2.X + directions[d].X, b.Item2.Y + directions[d].Y)));
                    boxes.Remove(b);
                }
                if (canRobotMove)
                    robotPosition = (robotPosition.X + directions[d].X, robotPosition.Y + directions[d].Y);
            }
            return boxes.Sum(x => x.Item1.X + x.Item2.Y * 100);
        }
    }
}
