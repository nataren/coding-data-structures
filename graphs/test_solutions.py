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
        bfs_discovered_items = sorted(list(graph.bfs()))
        expected = sorted([0, 1, 4, 5, 3, 2])
        assert bfs_discovered_items == expected

