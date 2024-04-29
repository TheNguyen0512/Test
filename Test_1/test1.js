function combineArrays(arrays) {
    /**
     * Hàm `combineHelper` sinh đệ quy tất cả các tổ hợp có thể của các phần tử từ nhiều mảng.
     * @param index - Tham số `index` trong hàm `combineHelper` được sử dụng để theo dõi
     * mảng hiện tại đang được xử lý trong mảng `arrays`. Nó giúp trong việc lặp qua từng
     * mảng và các phần tử của nó để tạo ra các tổ hợp.
     * @param currentCombination - Tham số `currentCombination` là một mảng lưu trữ
     * tổ hợp hiện tại của các phần tử đang được xây dựng trong quá trình đệ quy để tạo ra
     * các tổ hợp từ nhiều mảng. Nó được truyền cùng với tham số `index` để theo dõi
     * các phần tử đã chọn cho đến nay trong tổ hợp.
     * @returns Hàm `combineHelper` không trực tiếp trả về gì cả, vì nó sử dụng một câu lệnh `return;`
     * mà không có giá trị. Hàm chủ yếu được sử dụng cho các hiệu ứng phụ, như
     * điền mảng `combinations` với các tổ hợp được tạo ra trong quá trình thực thi của nó.
     */
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