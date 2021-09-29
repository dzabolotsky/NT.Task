import * as React from "react";
import { AutoComplete, Button, Input } from "antd";
import "antd/dist/antd.css";
import { SearchOutlined } from "@ant-design/icons";
import * as CitiesStore from "../../store/City";
const { Search } = Input;
interface IProps {
  onSearch: (name?: string) => Promise<void>;
  onChange: (name: string) => Promise<void>;
  onClear: () => Promise<void>;
}

export default class ContentSearch extends React.Component<IProps> {
  onChange = (value: string) => {
    if (!value) this.props.onClear();
    else this.props.onChange(value);
  };
  public render() {
    const dataSource = [
      "Düsseldorf",
      "Berlin",
      "Leipzig",
      "München",
      "Essen",
      "Dortmund",
      "Hamburg",
      "Köln",
      "Stuttgart",
      "Frankfurt am Main",
    ];

    return (
      <div>
        <span>
          <AutoComplete
            dataSource={dataSource}
            style={{ width: "80%" }}
            onSearch={this.props.onSearch}
            onChange={this.onChange}
            onSelect={this.props.onSearch}
            placeholder="Stadtname"
            filterOption={(inputValue, option) => {
              if (option)
                return (
                  option.props.children
                    .toUpperCase()
                    .indexOf(inputValue.toUpperCase()) !== -1
                );
              return false;
            }}
          ></AutoComplete>
        </span>
        <span>
          <Button type="primary" onClick={(e) => this.props.onSearch}>
            Suchen
          </Button>
        </span>
      </div>
    );
  }
}
