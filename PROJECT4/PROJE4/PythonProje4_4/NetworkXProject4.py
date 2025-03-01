import networkx as nx
import matplotlib.pyplot as plt
graph = nx.DiGraph()

graph.add_node("Olivia")
graph.add_node("Jack")
graph.add_node("Celine")
graph.add_node("John")
graph.add_node("Winston")
graph.add_node("Olivia")
graph.add_edge("Olivia", "Celine", weight = 8)
graph.add_edge("Olivia", "Jack", weight = 4)
graph.add_edge("Olivia", "John", weight = 7)
graph.add_edge("Celine", "Jack", weight = 5)
graph.add_edge("Celine", "Winston", weight = 6)
graph.add_edge("Winston", "Jack", weight = 7)
graph.add_edge("Winston", "Chloe", weight = 11)
graph.add_edge("Chloe", "Jack", weight = 5)
graph.add_edge("Chloe", "John", weight = 7)
graph.add_edge("John", "Jack", weight = 9)

people = ["Olivia", "Jack", "Celine", "John", "Winston", "Chloe"]
for person1 in people:
    for person2 in people:
        if person1 != person2:
            try:
                shortest_path = nx.dijkstra_path(graph, source=person1, target=person2)
                shortest_distance = nx.shortest_path_length(graph, source=person1, target=person2, weight="weight")
                print(f"En kısa yol ({person1} -> {person2}): {shortest_path}")
                print(f"Uzaklık: {shortest_distance}")
            except nx.NetworkXNoPath:
                print(f"({person1} -> {person2}): Yol bulunamadı.")
            print("------------------------")

dfs_edges = list(nx.dfs_edges(graph, source="Olivia"))
print("DFS Yolu:", dfs_edges)

#(BFS) ile gezme
bfs_edges = list(nx.bfs_edges(graph, source="Olivia"))
print("BFS Yolu:", bfs_edges)

shell_layout = [["Jack"], ["Olivia", "Celine", "Winston", "Chloe", "John"]]
pos = nx.shell_layout(graph, nlist=shell_layout)

# Grafik çizimi
labels = nx.get_edge_attributes(graph, 'weight')

nx.draw(graph, pos, with_labels=True, node_size=700, node_color='skyblue', font_size=10, font_color='black')
nx.draw_networkx_edge_labels(graph, pos, edge_labels=labels)

plt.show()

