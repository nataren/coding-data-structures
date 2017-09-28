import pytest

from solutions import Graph

class TestGraph:
    def test_constructor(self):
        four = Graph.Node(4, [])
        three = Graph.Node(3, [
                four
            ])
        one = Graph.Node(1, [
            four,
            three
        ])
        two = Graph.Node(2, [
            one
        ])
        three.adjacents.append(two)

        nodes = [
            Graph.Node(0, [
                Graph.Node(5, []),
                four,
                one
            ])
        ]
        graph = Graph(nodes)
        bfs_discovered_items = list(graph.bfs())
        expected = [0, 5, 4, 1, 3, 2]
        assert bfs_discovered_items == expected

