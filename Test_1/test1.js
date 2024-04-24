function combineArrays(arrays) {
    function combineHelper(index, currentCombination) {
        if (index === arrays.length) {
            combinations.push(currentCombination.slice());
            return;
        }

        for (let i = 0; i < arrays[index].length; i++) {
            currentCombination.push(arrays[index][i]);
            combineHelper(index + 1, currentCombination);
            currentCombination.pop();
        }
    }

    const combinations = [];
    combineHelper(0, []);
    return combinations;
}

const arrays = [
    ['A1', 'A2', 'Aa'],
    ['B1', 'B2', 'Bb'],
    ['C1', 'C2', 'Cc'],
    ['F1', 'F2', 'Ff']
];

const result = combineArrays(arrays);
for (let i = 0; i < result.length; i++) {
    console.log(result[i]);
}