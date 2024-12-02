import pygame

# Initialize Pygame
pygame.init()

# Screen dimensions
WIDTH, HEIGHT = 600, 600
ROWS, COLS = 30, 30
CELL_SIZE = WIDTH // COLS

# Colors
WHITE = (255, 255, 255)
BLACK = (0, 0, 0)
BLUE = (0, 0, 255)
RED = (255, 0, 0)
GREEN = (0, 255, 0)
GRAY = (169, 169, 169)

# Create the screen
screen = pygame.display.set_mode((WIDTH, HEIGHT))
pygame.display.set_caption("Pathfinding in Grid-Based Game")

# Directions for movement (Right, Left, Down, Up)
DIRECTIONS = [(1, 0), (-1, 0), (0, 1), (0, -1)]

# DFS Algorithm for pathfinding
def dfs(maze, start, end):
    stack = [start]
    visited = set()
    parent = {}  # To reconstruct the path

    while stack:
        x, y = stack.pop()

        if (x, y) == end:
            path = reconstruct_path(parent, start, end)
            return path

        if (x, y) not in visited:
            visited.add((x, y))

            for dx, dy in DIRECTIONS:
                nx, ny = x + dx, y + dy

                if (0 <= nx < COLS and 0 <= ny < ROWS and 
                    maze[ny][nx] == 0 and (nx, ny) not in visited):
                    
                    stack.append((nx, ny))
                    parent[(nx, ny)] = (x, y)  # Track the path

                    # Draw the maze and the current path
                    draw_maze(maze)
                    pygame.draw.rect(screen, BLUE, (nx * CELL_SIZE, ny * CELL_SIZE, CELL_SIZE, CELL_SIZE))
                    pygame.display.flip()
                    pygame.time.delay(30)  # Adjust delay for visualization

    return []  # Return an empty list if no path is found

# Reconstruct the path from end to start
def reconstruct_path(parent, start, end):
    path = []
    current = end
    while current:
        path.append(current)
        if current == start:
            break
        current = parent.get(current)
    path.reverse()
    return path

# Draw the maze
def draw_maze(maze):
    for y in range(ROWS):
        for x in range(COLS):
            color = WHITE if maze[y][x] == 0 else BLACK
            pygame.draw.rect(screen, color, (x * CELL_SIZE, y * CELL_SIZE, CELL_SIZE, CELL_SIZE))

# Main game loop
def main():
    maze = [[0 for _ in range(COLS)] for _ in range(ROWS)]
    start = None
    end = None
    placing_obstacles = False

    running = True
    path = []

    while running:
        screen.fill(WHITE)
        draw_maze(maze)

        if start:
            pygame.draw.rect(screen, GREEN, (start[0] * CELL_SIZE, start[1] * CELL_SIZE, CELL_SIZE, CELL_SIZE))
        if end:
            pygame.draw.rect(screen, RED, (end[0] * CELL_SIZE, end[1] * CELL_SIZE, CELL_SIZE, CELL_SIZE))

        for position in path:
            pygame.draw.rect(screen, BLUE, (position[0] * CELL_SIZE, position[1] * CELL_SIZE, CELL_SIZE, CELL_SIZE))

        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                running = False
            if event.type == pygame.MOUSEBUTTONDOWN:
                x, y = pygame.mouse.get_pos()
                grid_x, grid_y = x // CELL_SIZE, y // CELL_SIZE

                if placing_obstacles:
                    maze[grid_y][grid_x] = 1 - maze[grid_y][grid_x]  # Toggle obstacles
                else:
                    if not start:
                        start = (grid_x, grid_y)
                    elif not end:
                        end = (grid_x, grid_y)

            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_SPACE and start and end:
                    path = dfs(maze, start, end)
                if event.key == pygame.K_o:
                    placing_obstacles = not placing_obstacles

        pygame.display.flip()

    pygame.quit()

if __name__ == "__main__":
    main()
